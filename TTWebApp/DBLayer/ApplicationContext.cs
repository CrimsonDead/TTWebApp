using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TTWebApp.Models;

namespace TTWebApp.DBLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
