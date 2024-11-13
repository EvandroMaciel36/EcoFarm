using EcoFarm.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoFarm.data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

            public DbSet<LoginModel> CONTA {  get; set; }

                protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginModel>().HasNoKey(); // Configura LoginModel como uma entidade sem chave
        base.OnModelCreating(modelBuilder);
    }

    }
}
