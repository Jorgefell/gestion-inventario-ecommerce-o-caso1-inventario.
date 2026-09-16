using Casos1.Models;

namespace Casos1.Services;

public interface IDetallePedidoProveedorService
{
    Task<IEnumerable<Detallespedidoproveedor>> ObtenerTodosAsync();
    Task<Detallespedidoproveedor?> ObtenerPorIdAsync(int id);
    Task<Detallespedidoproveedor> CrearAsync(
        Detallespedidoproveedor detalle);
    Task<bool> ActualizarAsync(
        int id,
        Detallespedidoproveedor detalle);
    Task<bool> EliminarAsync(int id);
}