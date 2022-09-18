using Demo.Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DAL.Concrete
{
    public class NorthwindContext:IdentityDbContext
    {
        public NorthwindContext()
        {

        }
        public NorthwindContext(DbContextOptions<NorthwindContext> dbContextOptions):base(dbContextOptions)
        {

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Şifreli olanlar için...
            optionsBuilder.UseSqlServer("Server=DESKTOP-SUVH9IU\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=true;");

            //Şifresiz olanlar için 
           // "Server=DESKTOP-SUVH9IU\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=true;"
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
