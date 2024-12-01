namespace BidNest.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentTime { get; set; }
    public User Payer { get; set; }
    public int PayerId { get; set; }
    public Car Item { get; set; }
    public int ItemId { get; set; }
}
