using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
namespace dotnetapp.Repositories
{


public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId);
    Task<IEnumerable<Product>> GetApprovedProductsAsync();
    Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, string category);
}
}