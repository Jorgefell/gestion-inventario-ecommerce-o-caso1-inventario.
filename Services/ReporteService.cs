using Casos1.Models;
using Casos1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Casos1.Services;

public class ReporteService : IReporteService
{
    private readonly AppDbContext _context;

    public ReporteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<object> ObtenerEstadoInventarioAsync()
    {
        try
        {
            var productos = await _context.Productos
                .Select(p => new
                {
                    p.Id,
                    p.Nombre,
                    p.Categoria,
                    p.CantidadInventario,
                    p.StockMinimo,
                    Estado = p.CantidadInventario <= p.StockMinimo
                        ? "STOCK BAJO"
                        : "STOCK NORMAL"
                })
                .ToListAsync();

            return productos;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al generar el reporte de inventario.", ex);
        }
    }

    public async Task<object> ObtenerProductosMasVendidosAsync()
    {
        try
        {
            var productos = await _context.Detallestransaccions
                .Where(d =>
                    d.Transaccion != null &&
                    d.Transaccion.TipoTransaccion == "VENTA" &&
                    d.Producto != null)
                .GroupBy(d => new
                {
                    d.ProductoId,
                    NombreProducto = d.Producto!.Nombre
                })
                .Select(g => new
                {
                    ProductoId = g.Key.ProductoId,
                    Producto = g.Key.NombreProducto,
                    CantidadVendida = g.Sum(d => d.Cantidad)
                })
                .OrderByDescending(x => x.CantidadVendida)
                .ToListAsync();

            return productos;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al generar el reporte de productos más vendidos.",
                ex);
        }
    }
}