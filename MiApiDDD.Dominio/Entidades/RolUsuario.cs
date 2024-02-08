namespace MiApiDDD.Dominio.Entidades;

public class RolUsuario
{
    public Guid ID { get; set; }
    public Guid IDROL { get; set; }
    public Guid IDUSUARIO { get; set; }
    public DateTime FECHACREACION { get; set; }
    public DateTime FECHAACTUALIZACION { get; set; }
    public int ESTADO { get; set; }

    // Propiedades de navegación si las hay
    public Rol Rol { get; set; }
    public Usuario Usuario { get; set; }
}