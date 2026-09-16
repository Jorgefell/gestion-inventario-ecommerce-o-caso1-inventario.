using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class TransaccionService : ITransaccionService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransaccionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Transaccione>> ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork.Transacciones.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener las transacciones.", ex);
        }
    }

    public async Task<Transaccione?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork.Transacciones.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al obtener la transacción.", ex);
        }
    }

    public async Task<Transaccione> RegistrarAsync(
        Transaccione transaccion)
    {
        try
        {
            if (transaccion.TipoTransaccion != "COMPRA" &&
                transaccion.TipoTransaccion != "VENTA")
            {
                throw new ValidacionException(
                    "El tipo de transacción debe ser COMPRA o VENTA.");
            }

            if (transaccion.Detallestransaccions == null ||
                !transaccion.Detallestransaccions.Any())
            {
                throw new ValidacionException(
                    "La transacción debe tener al menos un detalle.");
            }

            transaccion.Fecha = DateTime.Now;

            foreach (var detalle in transaccion.Detallestransaccions)
            {
                var producto =
                    await _unitOfWork.Productos
                        .GetByIdAsync(detalle.ProductoId);

                if (producto == null)
                {
                    throw new ValidacionException(
                        $"No existe el producto con ID {detalle.ProductoId}.");
                }

                if (detalle.Cantidad <= 0)
                {
                    throw new ValidacionException(
                        "La cantidad debe ser mayor a cero.");
                }

                if (transaccion.TipoTransaccion == "VENTA")
                {
                    if (producto.CantidadInventario < detalle.Cantidad)
                    {
                        throw new ValidacionException(
                            $"Stock insuficiente para el producto {producto.Nombre}.");
                    }

                    producto.CantidadInventario -= detalle.Cantidad;
                }
                else
                {
                    producto.CantidadInventario += detalle.Cantidad;
                }

                detalle.PrecioUnitario = producto.Precio;

                var historial = new Historialinventario
                {
                    ProductoId = detalle.ProductoId,
                    TipoMovimiento =
                        transaccion.TipoTransaccion == "COMPRA"
                            ? "ENTRADA"
                            : "SALIDA",
                    Cantidad = detalle.Cantidad,
                    Fecha = DateTime.Now,
                    Origen = transaccion.TipoTransaccion
                };

                await _unitOfWork.HistorialInventarios
                    .AddAsync(historial);
            }

            transaccion.Total =
                transaccion.Detallestransaccions
                    .Sum(d => d.Cantidad * d.PrecioUnitario);

            await _unitOfWork.Transacciones
                .AddAsync(transaccion);

            await _unitOfWork.SaveChangesAsync();

            return transaccion;
        }
        catch (ValidacionException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al registrar la transacción.", ex);
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var transaccion =
                await _unitOfWork.Transacciones
                    .GetByIdAsync(id);

            if (transaccion == null)
                return false;

            _unitOfWork.Transacciones.Delete(transaccion);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(
                "Error al eliminar la transacción.", ex);
        }
    }
}