using ECommerce.Cart.Application.Features.Cart.Commands;
using ECommerce.Cart.Application.Features.Cart.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Cart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var cart = await _mediator.Send(new GetCartQuery(userId));

            if (cart == null)
                return NotFound("Cart not found");

            return Ok(cart);
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            await _mediator.Send(command);
            return Ok("Item added to cart");
        }
    }
}
