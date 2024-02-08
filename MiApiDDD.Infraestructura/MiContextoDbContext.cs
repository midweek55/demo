using MiApiDDD.Dominio.Entidades;
using MiApiDDD.Dominio.Entidades.MiApiDDD.Dominio.Entidades;
using MiApiDDD.Infraestructura.Configuracion;
using Microsoft.EntityFrameworkCore;

namespace MiApiDDD.Infraestructura
{
    public class MiContextoDbContext : DbContext
    {
        public MiContextoDbContext(DbContextOptions<MiContextoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<RolUsuario> RolUsuarios { get; set; }
        // Asumiendo la existencia de estas entidades basadas en tu descripción
        public DbSet<PermisoRol> PermisoRoles { get; set; }
        public DbSet<AccionModulo> AccionModulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de RolUsuario
            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.ToTable("RolUsuario", "Administracion"); // Asegúrate de especificar el esquema si es necesario

                entity.HasKey(e => e.ID);

                entity.Property(e => e.IDROL).HasColumnName("IDROL");
                entity.Property(e => e.IDUSUARIO).HasColumnName("IDUSUARIO");
                // Configura las demás propiedades según sea necesario

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IDROL);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolUsuarios)
                    .HasForeignKey(d => d.IDUSUARIO);
            });

            // Configuración de Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("ROL", "Administracion");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.Estado).IsRequired();
                // Configuraciones adicionales si son necesarias
            });

            // Configuración de Modulo
            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.ToTable("MODULO", "Administracion");
                entity.HasKey(e => e.ID);
                // Configuraciones adicionales si son necesarias
            });

            // Configuración de PermisoRol
            modelBuilder.Entity<PermisoRol>(entity =>
            {
                entity.ToTable("PermisoRol", "Administracion");
                entity.HasKey(pr => pr.ID);
                // Asume relaciones con Rol y AccionModulo
                entity.HasOne<Rol>(pr => pr.ROL)
                      .WithMany(r => r.PermisoRoles)
                      .HasForeignKey(pr => pr.IDROL);
                entity.HasOne(pr => pr.AccionModulo)
                      .WithMany(am => am.PermisoRoles)
                      .HasForeignKey(pr => pr.IDPERMISOMODULO);
            });

            // Configuración de AccionModulo
            modelBuilder.Entity<AccionModulo>(entity =>
            {
                entity.ToTable("AccionModulo", "Administracion");
                entity.HasKey(am => am.ID);
                // Asume relación con Modulo
                entity.HasOne(am => am.Modulo)
                      .WithMany(m => m.AccionModulos)
                      .HasForeignKey(am => am.IDMODULO);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            // Aplicar otras configuraciones específicas de la entidad...
        }
    }
}