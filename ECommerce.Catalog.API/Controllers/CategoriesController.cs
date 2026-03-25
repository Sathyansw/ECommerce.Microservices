using ECommerce.Catalog.Application.Features.Categories.Commands;
using ECommerce.Catalog.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery());
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            CreateCategoryCommand command
        )
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
