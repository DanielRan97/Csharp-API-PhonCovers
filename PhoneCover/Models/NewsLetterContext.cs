using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCover.Models
{
    public class NewsLetterContext : DbContext
    {


        public NewsLetterContext(DbContextOptions<NewsLetterContext> options) : base(options)
        {

        }

        public DbSet<NewsLetterDetails> newsLetter { get; set; }

    }
}
