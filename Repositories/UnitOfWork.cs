using Casos1.Models;

namespace Casos1.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IProductoRepository Productos { get; }
    public IProveedorRepository Proveedores { get; }
    public ITransaccionRepository Transacciones { get; }

    public IGenericRepository<Detallestransaccion> DetallesTransacciones { get; }
    public IGenericRepository<Historialinventario> HistorialInventarios { get; }
    public IGenericRepository<Pedidosproveedor> PedidosProveedores { get; }
    public IGenericRepository<Detallespedidoproveedor> DetallesPedidosProveedores { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        Productos = new ProductoRepository(_context);
        Proveedores = new ProveedorRepository(_context);
        Transacciones = new TransaccionRepository(_context);

        DetallesTransacciones =
            new GenericRepository<Detallestransaccion>(_context);

        HistorialInventarios =
            new GenericRepository<Historialinventario>(_context);

        PedidosProveedores =
            new GenericRepository<Pedidosproveedor>(_context);

        DetallesPedidosProveedores =
            new GenericRepository<Detallespedidoproveedor>(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}