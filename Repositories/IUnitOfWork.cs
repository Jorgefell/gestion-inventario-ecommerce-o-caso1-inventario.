using System.Threading.Tasks;

namespace Casos1.Repositories;

public interface IUnitOfWork : IDisposable
{
    IProductoRepository Productos { get; }
    IProveedorRepository Proveedores { get; }

    Task<int> SaveChangesAsync();
}