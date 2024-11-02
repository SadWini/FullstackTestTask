using Domain.Interfaces;

namespace Infrastracture;

public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<int, OrderDao>  _goodItems = new();
    private int currentOrderId = 0;
    public int Add(OrderDao order)
    { 
        int index = Interlocked.Increment(ref currentOrderId);
        order.Id = index;
        _goodItems.Add(index, order);
        return index;
    }

    public IReadOnlyList<OrderDao> GetAll()
    {
        return _goodItems.Values.ToList().AsReadOnly();
    }
}