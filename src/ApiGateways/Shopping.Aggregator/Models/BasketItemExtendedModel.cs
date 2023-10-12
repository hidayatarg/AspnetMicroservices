namespace Shopping.Aggregator.Models;
/// <summary>
/// It is the DTO of the Basket.API -> Entities -> ShoppingCartItem
/// </summary>
public class BasketItemExtendedModel
{
    public int Quantity { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }

    // Product Related Additional Fields -> these info will be retrieved from mongoDB by using productId
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
}