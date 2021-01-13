using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCover.Models
{
    public class CategoriesContext: DbContext
    {


        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options)
        {

        }

        public DbSet<CategoriesDetails> categories { get; set; }

    }
}
