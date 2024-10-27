using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Data
{
    public class Lab3Context : DbContext
    {
        public Lab3Context (DbContextOptions<Lab3Context> options)
            : base(options)
        {
        }

        public DbSet<Lab3.Models.Book> Books { get; set; } = default!;
    }
}
