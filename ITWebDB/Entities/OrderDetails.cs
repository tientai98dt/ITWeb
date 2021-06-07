using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public OrderDetails()
        {
        }

        [Key]

        [Display(Name = "Order Id")]
        [Column("OrderId", Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Display(Name = "Product Id")]
        [Column("ProductId", Order = 2)]
        public int ProductId { get; set; }

        [Display(Name = "Order Price")]
        [Column("OrderPrice")]
        public Nullable<decimal> OrderPrice { get; set; }

        [Display(Name = "Quantity")]
        [Column("Quantity")]
        public Nullable<int> Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
