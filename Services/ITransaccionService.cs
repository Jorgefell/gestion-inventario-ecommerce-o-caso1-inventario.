using Casos1.Models;

namespace Casos1.Services;

public interface ITransaccionService
{
    Task<IEnumerable<Transaccione>> ObtenerTodosAsync();
    Task<Transaccione?> ObtenerPorIdAsync(int id);

    Task<Transaccione> RegistrarAsync(Transaccione transaccion);

    Task<bool> EliminarAsync(int id);
}