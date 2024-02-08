using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace MiApiDDD.Dominio.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<string>> ObtenerNombresModulosPorUsuarioIdAsync(Guid usuarioId);
    }
}