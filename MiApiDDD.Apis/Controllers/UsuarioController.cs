using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiApiDDD.Aplicacion.Queries;
// Asegúrate de tener esta directiva para usar UsuarioDto
using System;
using System.Threading.Tasks;
using MiApiDDD.Dominio.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUsuarioRepository _usuarioRepository; // Asegúrate de tener esta línea

    public UsuariosController(IMediator mediator, IUsuarioRepository usuarioRepository) // Añade IUsuarioRepository como parámetro
    {
        _mediator = mediator;
        _usuarioRepository = usuarioRepository; // Asigna el parámetro al campo o propiedad
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
        var detallesUsuario = await _usuarioRepository.ObtenerDetallesUsuarioAsync(usuarioId);
        if (detallesUsuario == null)
        {
            return NotFound();
        }
        return Ok(detallesUsuario);
    }
}