using Casos1.Models;

namespace Casos1.Repositories;

public class TransaccionRepository : GenericRepository<Transaccione>, ITransaccionRepository
{
    public TransaccionRepository(AppDbContext context) : base(context)
    {
    }
}