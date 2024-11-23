using EcoFarm.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoFarm.data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

            public DbSet<CadastroModel> CONTA {  get; set; }
            public DbSet<ProdutoModel> PRODUTO { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CadastroModel>().HasNoKey(); // Configura LoginModel como uma entidade sem chave
        base.OnModelCreating(modelBuilder);
    }


    }
}
