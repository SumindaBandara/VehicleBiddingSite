using BidNest.Models;
using Microsoft.EntityFrameworkCore;
using sib_api_v3_sdk.Client;
using EmailSender = Sendinblue.EmailSender;

namespace BidNest.Services;

public class AuctionService
{
    private readonly ApplicationDbContext _context;
    private readonly string? _apiKey;
    private readonly string? _senderName;
    private readonly string? _senderEmail;

    public AuctionService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _apiKey = configuration.GetValue<string>("BrevoApi:ApiKey");
        _senderName = configuration.GetValue<string>("BrevoApi:SenderName");
        _senderEmail = configuration.GetValue<string>("BrevoApi:SenderEmail");
    }

    public async Task EndAuction(int itemId)
    {
        var item = await _context.Items.Include(i => i.Bids).FirstOrDefaultAsync(i => i.Id == itemId);
        if (item == null || !item.IsAuctionLive)
        {
            throw new InvalidOperationException("Invalid auction");
        }

        item.IsAuctionLive = false;

        var highestBid = item.Bids.OrderByDescending(b => b.Amount).FirstOrDefault();
        if (highestBid != null)
        {
            // Process payment and delivery
            var payment = new Payment
            {
                Amount = highestBid.Amount,
                PaymentTime = DateTime.UtcNow,
                PayerId = highestBid.BidderId,
                ItemId = item.Id
            };

            _context.Payments.Add(payment);

            // You can also trigger an email to the winner/seller here
            var bidder = await _context.Users.FindAsync(highestBid.BidderId);
            var seller = await _context.Users.FindAsync(item.SellerId);

            // Set your API key
            Configuration.Default.ApiKey.Add("api-key", _apiKey);

            // Send email to winner
            EmailSender.SendEmail(
                senderName: _senderName,
                senderEmail: _senderEmail,
                receiverEmail: bidder.Email,
                receiverName: bidder.UserName,
                subject: "You won the auction!",
                message: $"<html><body><h1>Congratulations! You won the auction for {item.Title}.</h1></body></html>"
            );

            // Send email to seller
            EmailSender.SendEmail(
                senderName: _senderName,
                senderEmail: _senderEmail,
                receiverEmail: seller.Email,
                receiverName: seller.UserName,
                subject: "Your auction has ended",
                message: $"<html><body><h1>Your auction for {item.Title} has ended. The winning bid was {highestBid.Amount:C}.</h1></body></html>"
            );
        }

        await _context.SaveChangesAsync();
    }
}
