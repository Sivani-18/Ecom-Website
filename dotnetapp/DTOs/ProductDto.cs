using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetapp.DTOs
{

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
    public ProductStatus Status { get; set; }
    public string SellerName { get; set; }
    public DateTime CreatedAt { get; set; }
}
}