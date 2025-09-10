using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models{


public class Order
{
    public int OrderId { get; set; }
    public int BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; }
    
    // Navigation properties
    public virtual User Buyer { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}

}