using Casos1.Models;
using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransaccionController : ControllerBase
{
    private readonly ITransaccionService _transaccionService;

    public TransaccionController(
        ITransaccionService transaccionService)
    {
        _transaccionService = transaccionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transaccione>>> ObtenerTodos()
    {
        try
        {
            var transacciones =
                await _transaccionService.ObtenerTodosAsync();

            return Ok(transacciones);
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new { mensaje = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaccione>> ObtenerPorId(int id)
    {
        try
        {
            var transaccion =
                await _transaccionService.ObtenerPorIdAsync(id);

            if (transaccion == null)
                return NotFound();

            return Ok(transaccion);
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Transaccione>> Registrar(
        Transaccione transaccion)
    {
        try
        {
            var nuevaTransaccion =
                await _transaccionService
                    .RegistrarAsync(transaccion);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = nuevaTransaccion.Id },
                nuevaTransaccion);
        }
        catch (ValidacionException ex)
        {
            return BadRequest(new
            {
                mensaje = ex.Message
            });
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new
                {
                    mensaje = ex.Message
                });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        try
        {
            var eliminado =
                await _transaccionService
                    .EliminarAsync(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new
                {
                    mensaje = ex.Message
                });
        }
    }
}