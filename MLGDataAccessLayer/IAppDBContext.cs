using Microsoft.EntityFrameworkCore;
using MLGDataAccessLayer.models;

namespace MLGDataAccessLayer
{
    public interface IAppDBContext
    {
        DbSet<ClienteModelo> Clientes { get; set; }
        DbSet<UsuarioModelo> Usuarios { get; set; }
        DbSet<TiendaModelo> Tiendas { get; set; }
        DbSet<ArticuloModelo> Articulos { get; set; }
        DbSet<ClienteArticuloModelo> ClienteArticulos { get; set; }
        DbSet<TiendaArticuloModelo> TiendaArticulos { get; set; }
        DbSet<UsuarioClienteModelo> UsuarioClientes { get; set; }
    }
}
