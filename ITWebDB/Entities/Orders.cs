using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{

    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Display(Name = "Order Id")]
        [Column("OrderId")]
        public int OrderId { get; set; }

        [Display(Name = "Customer Id")]
        [Column("CustomerId")]
        public Nullable<int> CustomerId { get; set; }

        [Display(Name = "Order Date")]
        [Column("OrderDate")]
        public Nullable<DateTime> OrderDate { get; set; }

        public virtual Customers Customer { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
    }
}
