
using BoletoAppSol.Data.Entitiies;
using Microsoft.EntityFrameworkCore;

namespace BoletoAppSol.Data.Context
{
    public  class BoletoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DbBoletos");
        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
    }
}
