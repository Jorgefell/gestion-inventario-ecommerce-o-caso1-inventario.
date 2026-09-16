using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetallePedidoProveedorController : ControllerBase
{
    private readonly IDetallePedidoProveedorService _service;

    public DetallePedidoProveedorController(
        IDetallePedidoProveedorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Detallespedidoproveedor>>>
        ObtenerTodos()
    {
        var detalles = await _service.ObtenerTodosAsync();

        return Ok(detalles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Detallespedidoproveedor>>
        ObtenerPorId(int id)
    {
        var detalle = await _service.ObtenerPorIdAsync(id);

        if (detalle == null)
            return NotFound();

        return Ok(detalle);
    }

    [HttpPost]
    public async Task<ActionResult<Detallespedidoproveedor>> Crear(
        Detallespedidoproveedor detalle)
    {
        var nuevoDetalle =
            await _service.CrearAsync(detalle);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevoDetalle.Id },
            nuevoDetalle
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(
        int id,
        Detallespedidoproveedor detalle)
    {
        var actualizado =
            await _service.ActualizarAsync(id, detalle);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado =
            await _service.EliminarAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}