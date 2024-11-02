using Swashbuckle.AspNetCore.Annotations;

namespace Web.Controllers.Dto;

[SwaggerSchema]
public class OrderDto
{
    [SwaggerSchema("Город отправителя")]
    public string SenderCity {get;set;}

    [SwaggerSchema("Адрес отправителя")]
    public string SenderAddress { get; set; }

    [SwaggerSchema("Город получателя")]
    public string RecipientCity { get; set; }
    
    [SwaggerSchema("Адрес получателя")]
    public string RecipientAddress { get; set; }
    
    [SwaggerSchema("Вес груза")]
    public decimal Weight { get; set; }
    
    [SwaggerSchema("Дата забора груза")]
    public DateTime PickupDate { get; set; }
}