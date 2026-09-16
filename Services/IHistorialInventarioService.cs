using Casos1.Models;

namespace Casos1.Services;

public interface IHistorialInventarioService
{
    Task<IEnumerable<Historialinventario>> ObtenerTodosAsync();
    Task<Historialinventario?> ObtenerPorIdAsync(int id);
}