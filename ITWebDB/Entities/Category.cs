using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    public class Category
    {
        [Key]
        [DisplayName("Danh mục")]
        public int CategoryId { get; set; }
        [DisplayName("Tên danh mục")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
