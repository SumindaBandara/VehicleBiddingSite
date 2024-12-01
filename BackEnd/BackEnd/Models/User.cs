namespace BidNest.Models;

public class User
{
    public string ClerkUserId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; } // Nullable property
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string DrivingLicense { get; set; } = string.Empty;
    public string PreferredBidType { get; set; } = string.Empty;
    public string BidderType { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public User Seller { get; set; }
    public ICollection<Car> Items { get; set; }

    public ICollection<Bidder> Bids { get; set; }

    public String Role { get; set; }




}