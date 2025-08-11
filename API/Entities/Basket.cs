using System;

namespace API.Entities;

public class Basket
{
    public int Id { get; set; }
    public required string BasketId { get; set; }
    public List<BasketItem> Items { get; set; } = [];


    public void AddItem(Product product, int quantity)
    {
        if (product == null) ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        var existingItem = FindItem(product.Id);

        if (existingItem == null)
        {
            Items.Add(new BasketItem
            {
                
                Quantity = quantity,
                Product = product
            });
        }
        else
        {
            existingItem.Quantity += quantity;
        }
    }

    public void RemoveItem(int productId, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        var item = FindItem(productId);
        if (item == null) return;

        if (item.Quantity > quantity)
        {
            item.Quantity -= quantity;
        }
        else
        {
            Items.Remove(item);
        }
    }
   

    private BasketItem? FindItem(int id)
    {
        return Items.FirstOrDefault(item => item.ProductId == id);
    }
}
