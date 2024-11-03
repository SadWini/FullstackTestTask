using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Web.Controllers.Dto;

namespace Web.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private ILogger<OrderController> _logger;
    private readonly IValidator<OrderDto> _validator;
    private readonly IOrderRepository _orderRepository;
    private int _orderCount;
    public OrderController(ILogger<OrderController> logger,
        IOrderRepository orderRepository,
        IValidator<OrderDto> validator)
    {
        _logger = logger;
        _orderRepository = orderRepository;
        _validator = validator;
        _orderCount = 0;
    }
    
    [HttpPost("addOrder")]
    [SwaggerOperation("метод добавления заказа")]
    public IActionResult AddGood(OrderDto orderDto)
    {
        var result = _validator.Validate(orderDto);
        if(!result.IsValid)
        {
            return BadRequest();
        }

        var newOrder = new OrderDao()
        {
            SenderCity = orderDto.SenderCity,
            SenderAddress = orderDto.SenderAddress,
            RecipientCity = orderDto.RecipientCity,
            RecipientAddress = orderDto.RecipientAddress,
            Weight = orderDto.Weight,
            PickupDate = orderDto.PickupDate.ToUniversalTime(),
        };

        _orderRepository.Add(newOrder);
        return CreatedAtAction(nameof(FindAll), new { id = newOrder.Id }, newOrder);
    }
    
    [HttpGet("findAll")]
    [SwaggerOperation("метод получения всех товаров")]
    public IActionResult FindAll(){
        var value = _orderRepository.GetAll();
        return Ok(value);
    }
}