using Casos1.Models;

namespace Casos1.Services;

public interface IProveedorService
{
    Task<IEnumerable<Proveedore>> ObtenerTodosAsync();
    Task<Proveedore?> ObtenerPorIdAsync(int id);
    Task<Proveedore> CrearAsync(Proveedore proveedor);
    Task<bool> ActualizarAsync(int id, Proveedore proveedor);
    Task<bool> EliminarAsync(int id);
}