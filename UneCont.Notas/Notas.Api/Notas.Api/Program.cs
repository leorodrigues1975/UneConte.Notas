using Notas.Api.Middleware;
using Notas.Application.Interfaces;
using Notas.Application.Services;
using Notas.Domain.Repositories;
using Notas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddSingleton<INotaRepository, InMemoryNotaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UneCont.Notas API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapFallbackToFile("frontend/index.html");

app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
