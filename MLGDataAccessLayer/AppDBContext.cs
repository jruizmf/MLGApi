using MLGDataAccessLayer;
using MLGDataAccessLayer.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MLGDataAccessLayer
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public virtual DbSet<ClienteModelo> Clientes { get; set; }
        public virtual DbSet<ArticuloModelo> Articulos { get; set; }
        public virtual DbSet<ClienteArticuloModelo> ClienteArticulos { get; set; }
        public virtual DbSet<TiendaArticuloModelo> TiendaArticulos { get; set; }
        public virtual DbSet<TiendaModelo> Tiendas { get; set; }
        public virtual DbSet<UsuarioModelo> Usuarios { get; set; }
        public virtual DbSet<UsuarioClienteModelo> UsuarioClientes { get; set; }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../MLGApi/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);

            return new AppDBContext(builder.Options);
        }
    }
}
