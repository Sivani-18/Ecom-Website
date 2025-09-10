using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetapp.DTOs
{

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    public string ImageUrl { get; set; }
}
}