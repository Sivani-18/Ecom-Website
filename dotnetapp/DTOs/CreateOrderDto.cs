using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnetapp.DTOs
{


public class CreateOrderDto
{
    public List<CreateOrderItemDto> OrderItems { get; set; }
    public string ShippingAddress { get; set; }
}

public class CreateOrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

}