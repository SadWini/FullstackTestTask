using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web.Controllers.Dto;

namespace Web.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IValidator<OrderDto> _validator;
    private readonly IOrderRepository _orderRepository;
    public OrderController(//ILogger<GoodsController> logger,
        IOrderRepository orderRepository,
        IValidator<OrderDto> validator)
    {
       //_logger = logger;
        _orderRepository = orderRepository;
        _validator = validator;
    }
    
    [HttpPost]
    [SwaggerOperation("метод добавления товара")]
    [Route("/addGood")]
    public IActionResult AddGood(OrderDto orderDto)
    {
        var result = _validator.Validate(orderDto);
        if(!result.IsValid)
        {
            return BadRequest();
        }

        var addedOrder = _orderRepository.Add(new OrderDao()
        {
            SenderCity = orderDto.SenderCity,
            SenderAddress= orderDto.SenderAddress,
            RecipientCity = orderDto.RecipientCity,
            RecipientAddress= orderDto.RecipientAddress,
            Weight = orderDto.Weight,
            PickupDate = orderDto.PickupDate,
        });
        return Ok(addedOrder);
    }
}