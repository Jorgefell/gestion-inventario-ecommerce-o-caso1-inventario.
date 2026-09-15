using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedorController : ControllerBase
{
    private readonly IProveedorService _proveedorService;

    public ProveedorController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proveedore>>> ObtenerTodos()
    {
        var proveedores = await _proveedorService.ObtenerTodosAsync();

        return Ok(proveedores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Proveedore>> ObtenerPorId(int id)
    {
        var proveedor = await _proveedorService.ObtenerPorIdAsync(id);

        if (proveedor == null)
            return NotFound();

        return Ok(proveedor);
    }

    [HttpPost]
    public async Task<ActionResult<Proveedore>> Crear(Proveedore proveedor)
    {
        var nuevoProveedor =
            await _proveedorService.CrearAsync(proveedor);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevoProveedor.Id },
            nuevoProveedor
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(
        int id,
        Proveedore proveedor)
    {
        var actualizado =
            await _proveedorService.ActualizarAsync(id, proveedor);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado =
            await _proveedorService.EliminarAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}