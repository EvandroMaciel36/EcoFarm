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
    }
}
