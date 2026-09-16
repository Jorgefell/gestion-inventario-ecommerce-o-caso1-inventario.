using Casos1.Models;

namespace Casos1.Services;

public interface IPedidoProveedorService
{
    Task<IEnumerable<Pedidosproveedor>> ObtenerTodosAsync();
    Task<Pedidosproveedor?> ObtenerPorIdAsync(int id);
    Task<Pedidosproveedor> CrearAsync(Pedidosproveedor pedido);
    Task<bool> ActualizarAsync(int id, Pedidosproveedor pedido);
    Task<bool> EliminarAsync(int id);
}