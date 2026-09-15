using Casos1.Models;

namespace Casos1.Repositories;

public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<IEnumerable<Producto>> ObtenerProductosStockBajoAsync();
}