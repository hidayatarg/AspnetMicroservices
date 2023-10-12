using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;

    public OrderService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    
    public Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
    {
        throw new NotImplementedException();
    }
}