using ITWebDB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Concrete
{
    public class ITWebEntities :DbContext
    {
        public ITWebEntities() :base ("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<CategoryFeedback> CategoryFeedbacks { get; set; }

        public System.Data.Entity.DbSet<ITWebDB.Entities.ShippingDetails> ShippingDetails { get; set; }
    }
}
