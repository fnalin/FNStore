using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FN.Store.Data.EF
{
    public class StoreDataContext: DbContext
    {
        private readonly IConfiguration _config;
        public StoreDataContext(IConfiguration config)
        {
            _config = config;
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    _config.GetConnectionString("StoreConn"),
                    opts =>
                    {
                        //opts.CommandTimeout(1000);
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ProdutoMap());

            modelBuilder.Seed();
        }

    }
}
