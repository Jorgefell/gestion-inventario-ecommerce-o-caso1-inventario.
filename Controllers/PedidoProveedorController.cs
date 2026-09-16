using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoProveedorController : ControllerBase
{
    private readonly IPedidoProveedorService _pedidoService;

    public PedidoProveedorController(
        IPedidoProveedorService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedidosproveedor>>> ObtenerTodos()
    {
        var pedidos = await _pedidoService.ObtenerTodosAsync();

        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pedidosproveedor>> ObtenerPorId(int id)
    {
        var pedido = await _pedidoService.ObtenerPorIdAsync(id);

        if (pedido == null)
            return NotFound();

        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult<Pedidosproveedor>> Crear(
        Pedidosproveedor pedido)
    {
        var nuevoPedido =
            await _pedidoService.CrearAsync(pedido);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevoPedido.Id },
            nuevoPedido
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(
        int id,
        Pedidosproveedor pedido)
    {
        var actualizado =
            await _pedidoService.ActualizarAsync(id, pedido);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado =
            await _pedidoService.EliminarAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}