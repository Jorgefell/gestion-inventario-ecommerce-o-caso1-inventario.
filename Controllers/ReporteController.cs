using Casos1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Casos1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReporteController : ControllerBase
{
    private readonly IReporteService _reporteService;

    public ReporteController(IReporteService reporteService)
    {
        _reporteService = reporteService;
    }

    [HttpGet("inventario")]
    public async Task<IActionResult> ObtenerEstadoInventario()
    {
        try
        {
            var reporte =
                await _reporteService.ObtenerEstadoInventarioAsync();

            return Ok(reporte);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                mensaje = ex.Message
            });
        }
    }

    [HttpGet("mas-vendidos")]
    public async Task<IActionResult> ObtenerProductosMasVendidos()
    {
        try
        {
            var reporte =
                await _reporteService.ObtenerProductosMasVendidosAsync();

            return Ok(reporte);
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