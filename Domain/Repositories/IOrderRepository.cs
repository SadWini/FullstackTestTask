namespace Domain.Interfaces;

public interface IOrderRepository
{
    void Add(OrderDao order);
    IReadOnlyList<OrderDao> GetAll();
}