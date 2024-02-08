using MiApiDDD.Aplicacion.DTOs;
using MiApiDDD.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MiApiDDD.Infraestructura.Repositorios;

public class UsuarioRepository : IUsuarioRepository, Aplicacion.Contratos.IUsuarioRepository
{
    private readonly MiContextoDbContext _context;

    public UsuarioRepository(MiContextoDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> ObtenerNombresModulosPorUsuarioIdAsync(Guid usuarioId)
    {
        var nombresModulos = await _context.RolUsuarios
            .Where(ru => ru.IDUSUARIO == usuarioId)
            .SelectMany(ru => ru.Rol.PermisoRoles) // De RolUsuario a PermisoRol
            .Select(pr => pr.AccionModulo.Modulo.Nombre) // De PermisoRol a AccionModulo, luego a Modulo
            .Distinct()
            .ToListAsync();

        return nombresModulos;
    }
    

    public async Task<UsuarioDto> ObtenerDetallesUsuarioAsync(Guid usuarioId)
    {
        var usuarioConRol = await _context.Usuarios
            .Where(u => u.Id == usuarioId)
            .Select(u => new UsuarioDto
            {
                Nombre = u.Nombres,
                Apellidos = u.Apellidos,
                Rol = u.RolUsuarios
                    .Select(ru => ru.Rol.Nombre) // Asume que existe la propiedad NOMBRE en Rol
                    .FirstOrDefault() // Obtiene el nombre del primer rol
            })
            .FirstOrDefaultAsync();

        return usuarioConRol;
    }
}