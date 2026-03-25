using ECommerce.Catalog.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Features.Categories.Queries
{

    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
