using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodos()
    {
        var productos = await _productoService.ObtenerTodosAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> ObtenerPorId(int id)
    {
        var producto = await _productoService.ObtenerPorIdAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult<Producto>> Crear(Producto producto)
    {
        var nuevoProducto = await _productoService.CrearAsync(producto);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id = nuevoProducto.Id },
            nuevoProducto
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, Producto producto)
    {
        var actualizado = await _productoService.ActualizarAsync(id, producto);

        if (!actualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var eliminado = await _productoService.EliminarAsync(id);

        if (!eliminado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("stock-bajo")]
    public async Task<ActionResult<IEnumerable<Producto>>> ObtenerStockBajo()
    {
        var productos = await _productoService.ObtenerStockBajoAsync();

        return Ok(productos);
    }
}