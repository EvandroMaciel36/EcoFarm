using EcoFarm.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

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

            public DbSet<CarrinhoModel> CARRINHO { get; set; }
            public DbSet<ClienteModel> CLIENTE { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<ClienteModel>().HasKey(c => c.Id_cliente);
            modelBuilder.Entity<CadastroModel>().HasKey(c => c.Id_cliente); 
            modelBuilder.Entity<CadastroModel>()
                .HasOne<ClienteModel>(c => c.Cliente)
                .WithMany(c => c.Contas)
                .HasForeignKey(c => c.Id_cliente);

            base.OnModelCreating(modelBuilder);
    }


    }
}
