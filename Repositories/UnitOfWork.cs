using Casos1.Models;
using Microsoft.EntityFrameworkCore;

namespace Casos1.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IProductoRepository Productos { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Productos = new ProductoRepository(_context);
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