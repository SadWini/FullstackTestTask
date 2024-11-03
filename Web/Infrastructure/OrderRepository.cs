using Domain.Interfaces;

namespace Infrastracture;

public class OrderRepository : IOrderRepository
{
    private readonly DataContext _context;

    public OrderRepository(DataContext context)
    {
        _context = context;
    }
    public void Add(OrderDao order)
    { 
        _context.Add(order);
        _context.SaveChanges();
    }

    public IReadOnlyList<OrderDao> GetAll()
    {
        return _context.Orders.ToList().AsReadOnly();
    }
}