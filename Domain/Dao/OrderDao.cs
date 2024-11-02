using System.ComponentModel.DataAnnotations;

public class OrderDao
{
    public int Id { get; set; }
       
    [Required]
    public string SenderCity { get; set; }
       
    [Required]
    public string SenderAddress { get; set; }
       
    [Required]
    public string RecipientCity { get; set; }
       
    [Required]
    public string RecipientAddress { get; set; }
       
    [Required]
    public decimal Weight { get; set; }

    [Required]
    public DateTime PickupDate { get; set; }

    public string OrderNumber => $"ORD-{Id:D5}";
}