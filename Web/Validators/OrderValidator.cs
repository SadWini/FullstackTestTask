using FluentValidation;
using Web.Controllers.Dto;

namespace Domain.Web;

public class OrderValidator:AbstractValidator<OrderDto>
{
    public OrderValidator()
    {
        RuleFor(x=> x.SenderCity).NotNull().NotEmpty();
        RuleFor(x=> x.SenderAddress).NotNull().NotEmpty();
        RuleFor(x=> x.RecipientCity).NotNull().NotEmpty();
        RuleFor(x=> x.RecipientAddress).NotNull().NotEmpty();
        RuleFor(x => x.Weight).GreaterThan(0);
        RuleFor(x => x.PickupDate).NotNull();
    }
}