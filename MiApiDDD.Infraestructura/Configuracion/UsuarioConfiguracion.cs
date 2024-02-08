using MiApiDDD.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiApiDDD.Infraestructura.Configuracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios"); // Asegúrate de que el nombre de la tabla coincida con tu base de datos.

            builder.HasKey(u => u.Id); // Configura la clave primaria, asumiendo que se llama Id en tu base de datos.

            builder.Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(100); // Ajusta según las restricciones de tu esquema.

            builder.Property(u => u.Nombres)
                .IsRequired()
                .HasMaxLength(200); // Ajusta según las restricciones de tu esquema.

            builder.Property(u => u.Apellidos)
                .IsRequired()
                .HasMaxLength(200); // Ajusta según las restricciones de tu esquema.

            // Configura otras propiedades según tu esquema.

            // Si tienes relaciones, asegúrate de configurarlas para que coincidan con las restricciones de clave foránea de tu base de datos.
        }
    }
}