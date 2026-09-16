using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistorialInventarioController : ControllerBase
{
    private readonly IHistorialInventarioService _historialService;

    public HistorialInventarioController(
        IHistorialInventarioService historialService)
    {
        _historialService = historialService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Historialinventario>>> ObtenerTodos()
    {
        try
        {
            var historial =
                await _historialService.ObtenerTodosAsync();

            return Ok(historial);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                mensaje = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Historialinventario>> ObtenerPorId(int id)
    {
        try
        {
            var movimiento =
                await _historialService.ObtenerPorIdAsync(id);

            if (movimiento == null)
                return NotFound();

            return Ok(movimiento);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                mensaje = ex.Message
            });
        }
    }
}