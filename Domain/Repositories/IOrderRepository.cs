namespace Domain.Interfaces;

public interface IOrderRepository
{
    int Add(OrderDao order);
}