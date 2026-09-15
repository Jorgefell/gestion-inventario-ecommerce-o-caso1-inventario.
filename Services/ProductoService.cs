using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork.Productos.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los productos.", ex);
        }
    }

    public async Task<Producto?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork.Productos.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el producto.", ex);
        }
    }

    public async Task<Producto> CrearAsync(Producto producto)
    {
        try
        {
            await _unitOfWork.Productos.AddAsync(producto);
            await _unitOfWork.SaveChangesAsync();

            return producto;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear el producto.", ex);
        }
    }

    public async Task<bool> ActualizarAsync(int id, Producto producto)
    {
        try
        {
            var productoExistente = await _unitOfWork.Productos.GetByIdAsync(id);

            if (productoExistente == null)
            {
                return false;
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Categoria = producto.Categoria;
            productoExistente.CantidadInventario = producto.CantidadInventario;
            productoExistente.StockMinimo = producto.StockMinimo;
            productoExistente.ProveedorId = producto.ProveedorId;

            _unitOfWork.Productos.Update(productoExistente);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el producto.", ex);
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);

            if (producto == null)
            {
                return false;
            }

            _unitOfWork.Productos.Delete(producto);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el producto.", ex);
        }
    }

    public async Task<IEnumerable<Producto>> ObtenerStockBajoAsync()
    {
        try
        {
            return await _unitOfWork.Productos.ObtenerProductosStockBajoAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los productos con stock bajo.", ex);
        }
    }
}