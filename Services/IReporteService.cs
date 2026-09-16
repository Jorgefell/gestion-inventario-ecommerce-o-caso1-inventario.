namespace Casos1.Services;

public interface IReporteService
{
    Task<object> ObtenerEstadoInventarioAsync();
    Task<object> ObtenerProductosMasVendidosAsync();
}