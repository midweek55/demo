using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiApiDDD.Dominio.Interfaces;
using MiApiDDD.Infraestructura;
using MiApiDDD.Infraestructura.Repositorios;
using MediatR;
using System.Reflection;
using MiApiDDD.Aplicacion.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();

// Registro del contexto de la base de datos
builder.Services.AddDbContext<MiContextoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro del repositorio UsuarioRepository con la interfaz IUsuarioRepository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Registro de MediatR
builder.Services.AddMediatR(typeof(ObtenerModulosPorUsuarioIdHandler).Assembly);

// Asegúrate de agregar cualquier otro servicio que tu aplicación necesite aquí.

var app = builder.Build();

// Configura el HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();