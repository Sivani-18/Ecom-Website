using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.DTOs;
using dotnetapp.Data;
namespace dotnetapp.Services
{

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductRequestRepository _productRequestRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository productRepository,
        IProductRequestRepository productRequestRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _productRequestRepository = productRequestRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductDto>> GetApprovedProductsAsync()
    {
        var products = await _productRepository.GetApprovedProductsAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsBySellerAsync(int sellerId)
    {
        var products = await _productRepository.GetBySellerIdAsync(sellerId);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto, int sellerId)
    {
        var product = _mapper.Map<Product>(dto);
        product.SellerId = sellerId;
        product.Status = ProductStatus.Pending;
        product.CreatedAt = DateTime.UtcNow;

        var createdProduct = await _productRepository.AddAsync(product);

        var request = new ProductRequest
        {
            ProductId = createdProduct.ProductId,
            SellerId = sellerId,
            RequestType = RequestType.Add,
            RequestDate = DateTime.UtcNow,
            Status = RequestStatus.Pending
        };

        await _productRequestRepository.AddAsync(request);

        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<ProductDto> UpdateProductAsync(int id, UpdateProductDto dto, int sellerId)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null || product.SellerId != sellerId)
            throw new UnauthorizedAccessException("Product not found or access denied.");

        _mapper.Map(dto, product);
        await _productRepository.UpdateAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm, string category)
    {
        var products = await _productRepository.SearchAsync(searchTerm, category);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}

}