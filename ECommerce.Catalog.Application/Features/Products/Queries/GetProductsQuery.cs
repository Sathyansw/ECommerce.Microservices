using ECommerce.Catalog.Application.DTOs;
using ECommerce.Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Features.Products.Queries
{
    public record GetProductsQuery() : IRequest<List<ProductDto>>
    {
    }
}
