using Microsoft.EntityFrameworkCore;
using Subir_Archivo_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SubirArchivoApiContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MisReglasCors = "ReglasCors";  //politica activar cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: MisReglasCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MisReglasCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
