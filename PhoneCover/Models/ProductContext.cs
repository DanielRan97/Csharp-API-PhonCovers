using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneCover.Models;

namespace PhoneCover.Models
{
    public class ProductContext : DbContext
    {
        

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<ProductDetails> product { get; set; }

    }
}
