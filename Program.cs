using Microsoft.EntityFrameworkCore;
using ApiVigilancia.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configurar la conexión a SQL Server desde appsettings.json
builder.Services.AddDbContext<SistemaAccesosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// ✅ Agregar controladores y Swagger para documentación
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

