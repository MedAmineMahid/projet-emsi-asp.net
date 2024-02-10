namespace WebApplication2.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddToCart(Product product)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.ProductId == productId);

            if (itemToRemove != null)
            {
                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {
                    Items.Remove(itemToRemove);
                }
            }
        }

        public decimal GetTotal()
        {
            return Items.Sum(item => item.ProductPrice * item.Quantity);
        }

        public void ClearCart()
        {
            Items.Clear();
        }
    }
}
