using System;

namespace API.Entities.OrderAggregate;

public class Order
{
    public int Id { get; set; }
    public required string BuyerEmail { get; set; }
    public required ShippingAddress ShippingAddress { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
    public long Subtotal { get; set; }
    public long DeliveryFee { get; set; }

    public long Discount { get; set; }

    public required string PaymentIntentId { get; set; }
    public long Total => Subtotal + DeliveryFee - Discount;

    public required PaymentSummary PaymentSummary { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}
