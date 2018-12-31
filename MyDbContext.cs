using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_Web_API_Products.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base("constr") { }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToTable("tbl_products");
            modelBuilder.Entity<ProductModel>().HasKey(p => p.productid);
            modelBuilder.Entity<ProductModel>().Property(p => p.productname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ProductModel>().Property(p => p.productprice).IsRequired();
            modelBuilder.Entity<ProductModel>().Property(p => p.productcategory).IsRequired();
        }
    }
}