namespace BidNest.Models;

public class Bidder
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime BidTime { get; set; }
    public User Bidders { get; set; }
    public int BidderId { get; set; }
    public Car Item { get; set; }
    public int ItemId { get; set; }
    public bool IsHighest { get; set; }

    public ICollection<Car> Bid { get; set; }

    
}

