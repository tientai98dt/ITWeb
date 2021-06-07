using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public List<CartLine> Lines{get{return lineCollection;}}

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (line == null)
            {
                lineCollection.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection
                .RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        //Tính tổng tiền giỏ hàng
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => (x.Product.Price * x.Quantity));
        }

        public void UpdateProductByProductID(Product product, int quantity) 
        {
            var line = lineCollection
                .FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (line != null)
            {
                line.Quantity = quantity;
            }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
