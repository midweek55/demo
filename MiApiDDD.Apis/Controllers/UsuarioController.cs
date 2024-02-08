using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiApiDDD.Aplicacion.Queries;
using MiApiDDD.Aplicacion.DTOs; // Asegúrate de tener esta directiva para usar UsuarioDto
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{usuarioId}/modulos")]
    public async Task<IActionResult> GetModulos(Guid usuarioId)
    {
        var query = new ObtenerModulosPorUsuarioIdQuery(usuarioId);
        var modulos = await _mediator.Send(query);
        return Ok(modulos);
    }

    // Nuevo endpoint para obtener los detalles del usuario
    [HttpGet("{usuarioId}/detalles")]
    public async Task<IActionResult> GetDetalles(Guid usuarioId)
    {
        var query = new ObtenerDetallesUsuarioQuery(usuarioId); // Asume la existencia de esta consulta
        var detallesUsuario = await _mediator.Send(query);

        if (detallesUsuario == null)
        {
            return NotFound();
        }

        return Ok(detallesUsuario);
    }
}