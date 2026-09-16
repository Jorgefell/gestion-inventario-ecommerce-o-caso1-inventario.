using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class DetallePedidoProveedorService
    : IDetallePedidoProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public DetallePedidoProveedorService(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Detallespedidoproveedor>>
        ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork
                .DetallesPedidosProveedores
                .GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener los detalles de pedidos.", ex);
        }
    }

    public async Task<Detallespedidoproveedor?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork
                .DetallesPedidosProveedores
                .GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener el detalle del pedido.", ex);
        }
    }

    public async Task<Detallespedidoproveedor> CrearAsync(
        Detallespedidoproveedor detalle)
    {
        try
        {
            await _unitOfWork
                .DetallesPedidosProveedores
                .AddAsync(detalle);

            await _unitOfWork.SaveChangesAsync();

            return detalle;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al crear el detalle del pedido.", ex);
        }
    }

    public async Task<bool> ActualizarAsync(
        int id,
        Detallespedidoproveedor detalle)
    {
        try
        {
            var existente =
                await _unitOfWork
                    .DetallesPedidosProveedores
                    .GetByIdAsync(id);

            if (existente == null)
                return false;

            existente.PedidoProveedorId =
                detalle.PedidoProveedorId;

            existente.ProductoId =
                detalle.ProductoId;

            existente.Cantidad =
                detalle.Cantidad;

            existente.PrecioUnitario =
                detalle.PrecioUnitario;

            _unitOfWork
                .DetallesPedidosProveedores
                .Update(existente);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al actualizar el detalle del pedido.", ex);
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var detalle =
                await _unitOfWork
                    .DetallesPedidosProveedores
                    .GetByIdAsync(id);

            if (detalle == null)
                return false;

            _unitOfWork
                .DetallesPedidosProveedores
                .Delete(detalle);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al eliminar el detalle del pedido.", ex);
        }
    }
}