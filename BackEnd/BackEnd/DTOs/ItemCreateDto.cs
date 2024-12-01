namespace BidNest.DTOs;

public class ItemCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal StartingPrice { get; set; }
    public DateTime EndTime { get; set; }
    public int SellerId { get; set; }
}
