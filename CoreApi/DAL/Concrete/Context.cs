using CoreApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.DAL.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SALIMOV\\SQLEXPRESS;Database=CoreApi;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
