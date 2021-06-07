using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
   public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Giá")]
        public decimal Price { get; set; }
        [DisplayName("Số lượng")]
        public int Amount { get; set; }
        [DisplayName("Thuộc danh mục")]
        public int CategoryId { get; set; }
        [DisplayName("Ảnh")]
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
