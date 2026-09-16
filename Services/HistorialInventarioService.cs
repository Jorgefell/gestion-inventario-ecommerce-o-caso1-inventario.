using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class HistorialInventarioService : IHistorialInventarioService
{
    private readonly IUnitOfWork _unitOfWork;

    public HistorialInventarioService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Historialinventario>> ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork.HistorialInventarios.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener el historial de inventario.", ex);
        }
    }

    public async Task<Historialinventario?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork.HistorialInventarios.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener el movimiento de inventario.", ex);
        }
    }
}