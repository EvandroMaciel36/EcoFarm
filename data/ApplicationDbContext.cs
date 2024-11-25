using EcoFarm.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EcoFarm.data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

            public DbSet<CadastroModel> CONTA {  get; set; }

            public DbSet<LoginModel> LOGIN {  get; set; }

            public DbSet<ProdutoModel> PRODUTO { get; set; }

            public DbSet<CarrinhoDeComprasModel> CARRINHO { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginModel>().HasNoKey(); // Configura LoginModel como uma entidade sem chave
        base.OnModelCreating(modelBuilder);
    }


    }
}
