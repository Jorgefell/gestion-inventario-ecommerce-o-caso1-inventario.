using Casos1.Models;
using Microsoft.EntityFrameworkCore;
using Casos1.Repositories;
using Casos1.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Configurar Entity Framework Core con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(
        builder.Configuration.GetConnectionString("DefaultConnection")!
    ));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<IPedidoProveedorService, PedidoProveedorService>();
builder.Services.AddScoped<IDetallePedidoProveedorService, DetallePedidoProveedorService>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<
    IHistorialInventarioService,
    HistorialInventarioService>();

// Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar los controladores
app.MapControllers();

app.Run();