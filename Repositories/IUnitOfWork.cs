using Casos1.Models;
using System.Threading.Tasks;

namespace Casos1.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductoRepository Productos { get; }
    IProveedorRepository Proveedores { get; }
    ITransaccionRepository Transacciones { get; }
    IGenericRepository<Detallestransaccion> DetallesTransacciones { get; }
    IGenericRepository<Historialinventario> HistorialInventarios { get; }
    IGenericRepository<Pedidosproveedor> PedidosProveedores { get; }
    IGenericRepository<Detallespedidoproveedor> DetallesPedidosProveedores { get; }

    Task<int> SaveChangesAsync();
}