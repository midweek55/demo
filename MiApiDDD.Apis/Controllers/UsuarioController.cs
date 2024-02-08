using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiApiDDD.Aplicacion.Queries;
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
    public async Task<IActionResult> Get(Guid usuarioId)
    {
        var query = new ObtenerModulosPorUsuarioIdQuery(usuarioId);
        var modulos = await _mediator.Send(query);
        return Ok(modulos);
    }
}