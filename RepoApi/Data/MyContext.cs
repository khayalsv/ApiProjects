using Microsoft.EntityFrameworkCore;
using RepoApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoApi.Data
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }

    }
}
