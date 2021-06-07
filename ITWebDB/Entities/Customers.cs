using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{

    [Table("Customers")]
    public class Customers
    {
        [Key]
        [Display(Name = "Customer Id")]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Display(Name = "Address")]
        [Column("Address")]
        public string Address { get; set; }

        [Display(Name = "Customer Name")]
        [Column("CustomerName")]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Column("Phone")]
        public string Phone { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
    }
    }
