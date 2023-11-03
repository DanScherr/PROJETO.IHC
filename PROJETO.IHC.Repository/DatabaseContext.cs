using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.IHC.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        // entidades

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"string de conexão");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model building das entities

            base.OnModelCreating(modelBuilder);

            // carregar seeds
        }
    }
}
