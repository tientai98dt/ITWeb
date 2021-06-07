using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Entities
{
    public class ProductDetails
    {
        [Key]
        public int ProductDetailID { get; set; }
        public string ManHinh { get; set; }
        public string HeDieuHanh { get; set; }
        public string CameraSau { get; set; }
        public string CameraTruoc { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string BoNhoTrong { get; set; }
        public string DungLuongPin { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
