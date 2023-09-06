using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketRepository _repository;
    private readonly DiscountGrpcService _discountGrpcService;

    public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
    }

    [HttpGet("{userName}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
        var basket = await _repository.GetBasket(userName);
        // if the basket is not create we return a new one
        return Ok(basket ?? new ShoppingCart(userName));
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
    {
        // Todo: Communicate with Discount.Grpc
        // and Calculate latest prices of product into shopping cart
        // consume Discount Grpc

        //foreach (var item in basket.Items)
        //{
        //    var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
        //    item.Price -= coupon.Amount;
        //}

        return Ok(await _repository.UpdateBasket(basket));
    }
    
    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(typeof(void),StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        await _repository.DeleteBasket(userName);
        return Ok();
    }
}