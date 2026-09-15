using Casos1.Models;

namespace Casos1.Services;

public interface IProductoService
{
    Task<IEnumerable<Producto>> ObtenerTodosAsync();
    Task<Producto?> ObtenerPorIdAsync(int id);
    Task<Producto> CrearAsync(Producto producto);
    Task<bool> ActualizarAsync(int id, Producto producto);
    Task<bool> EliminarAsync(int id);
    Task<IEnumerable<Producto>> ObtenerStockBajoAsync();
}