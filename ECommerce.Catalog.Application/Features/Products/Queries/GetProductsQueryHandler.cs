using ECommerce.Catalog.Application.DTOs;
using ECommerce.Catalog.Application.Interfaces;
using ECommerce.Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Features.Products.Queries
{
    public class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {

        private readonly IProductRepository _repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<List<ProductDto>> Handle(
       GetProductsQuery request,
       CancellationToken cancellationToken)
        {
            return await _repository
                .GetProductsWithCategoryAsync();
        }
    }
}
