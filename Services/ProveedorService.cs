using Casos1.Models;
using Casos1.Repositories;

namespace Casos1.Services;

public class ProveedorService : IProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProveedorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Proveedore>> ObtenerTodosAsync()
    {
        try
        {
            return await _unitOfWork.Proveedores.GetAllAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los proveedores.", ex);
        }
    }

    public async Task<Proveedore?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _unitOfWork.Proveedores.GetByIdAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el proveedor.", ex);
        }
    }

    public async Task<Proveedore> CrearAsync(Proveedore proveedor)
    {
        try
        {
            await _unitOfWork.Proveedores.AddAsync(proveedor);
            await _unitOfWork.SaveChangesAsync();

            return proveedor;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al crear el proveedor.", ex);
        }
    }

    public async Task<bool> ActualizarAsync(int id, Proveedore proveedor)
    {
        try
        {
            var proveedorExistente =
                await _unitOfWork.Proveedores.GetByIdAsync(id);

            if (proveedorExistente == null)
                return false;

            proveedorExistente.Nombre = proveedor.Nombre;
            proveedorExistente.Contacto = proveedor.Contacto;
            proveedorExistente.Telefono = proveedor.Telefono;
            proveedorExistente.Email = proveedor.Email;

            _unitOfWork.Proveedores.Update(proveedorExistente);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el proveedor.", ex);
        }
    }

    public async Task<bool> EliminarAsync(int id)
    {
        try
        {
            var proveedor =
                await _unitOfWork.Proveedores.GetByIdAsync(id);

            if (proveedor == null)
                return false;

            _unitOfWork.Proveedores.Delete(proveedor);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el proveedor.", ex);
        }
    }
}