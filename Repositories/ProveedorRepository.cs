using Casos1.Models;

namespace Casos1.Repositories;

public class ProveedorRepository : GenericRepository<Proveedore>, IProveedorRepository
{
    public ProveedorRepository(AppDbContext context) : base(context)
    {
    }
}