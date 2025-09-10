using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;
namespace dotnetapp.Repositories
{

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Product>> GetBySellerIdAsync(int sellerId)
    {
        return await _dbSet
            .Where(p => p.SellerId == sellerId)
            .Include(p => p.Seller)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> GetApprovedProductsAsync()
    {
        return await _dbSet
            .Where(p => p.Status == ProductStatus.Approved && p.Quantity > 0)
            .Include(p => p.Seller)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> GetProductsByStatusAsync(ProductStatus status)
    {
        return await _dbSet
            .Where(p => p.Status == status)
            .Include(p => p.Seller)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, string category)
    {
        var query = _dbSet.Where(p => p.Status == ProductStatus.Approved);
        
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
        }
        
        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(p => p.Category == category);
        }
        
        return await query.Include(p => p.Seller).ToListAsync();
    }
}
}