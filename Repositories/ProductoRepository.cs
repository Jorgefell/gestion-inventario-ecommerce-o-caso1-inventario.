using Casos1.Models;
using Microsoft.EntityFrameworkCore;

namespace Casos1.Repositories;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Producto>> ObtenerProductosStockBajoAsync()
    {
        return await _dbSet
            .Where(p => p.CantidadInventario <= p.StockMinimo)
            .ToListAsync();
    }
}