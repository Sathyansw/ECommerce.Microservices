using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Application.Services;

namespace ECommerce.Order.Infrastructure.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto?> GetProduct(Guid productId)
        {
            return await _httpClient
                .GetFromJsonAsync<ProductDto>(
                    $"https://localhost:7240/api/products/{productId}");
        }
    }
}