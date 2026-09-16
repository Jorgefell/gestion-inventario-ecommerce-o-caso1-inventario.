using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class PedidoProveedorService : IPedidoProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public PedidoProveedorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Pedidosproveedor>> ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork.PedidosProveedores.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener los pedidos de proveedores.", ex);
        }
    }

    public async Task<Pedidosproveedor?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork.PedidosProveedores.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener el pedido de proveedor.", ex);
        }
    }

    public async Task<Pedidosproveedor> CrearAsync(
        Pedidosproveedor pedido)
    {
        try
        {
            pedido.FechaPedido = DateTime.Now;

            await _unitOfWork.PedidosProveedores.AddAsync(pedido);
            await _unitOfWork.SaveChangesAsync();

            return pedido;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al crear el pedido de proveedor.", ex);
        }
    }

    public async Task<bool> ActualizarAsync(
        int id,
        Pedidosproveedor pedido)
    {
        try
        {
            var pedidoExistente =
                await _unitOfWork.PedidosProveedores.GetByIdAsync(id);

            if (pedidoExistente == null)
                return false;

            pedidoExistente.ProveedorId = pedido.ProveedorId;
            pedidoExistente.FechaPedido = pedido.FechaPedido;
            pedidoExistente.Estado = pedido.Estado;

            _unitOfWork.PedidosProveedores.Update(pedidoExistente);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al actualizar el pedido de proveedor.", ex);
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var pedido =
                await _unitOfWork.PedidosProveedores.GetByIdAsync(id);

            if (pedido == null)
                return false;

            _unitOfWork.PedidosProveedores.Delete(pedido);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al eliminar el pedido de proveedor.", ex);
        }
    }
}