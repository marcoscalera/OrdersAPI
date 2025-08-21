using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly ReadDbContext _context;

    public GetOrderByIdQueryHandler(ReadDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == request.OrderId);

        if (order == null)
            return null;

        return new OrderDto(
            order.Id,
            order.FirstName,
            order.LastName,
            order.Status,
            order.CreatedAt,
            order.TotalCost
        );
    }
    
    // public static async Task<Order?> Handle(GetOrderByIdQuey query, AppDbContext context)
    // {
    //     return await context.Orders.FirstOrDefaultAsync(o => o.Id == query.OrderId);
    // }
}