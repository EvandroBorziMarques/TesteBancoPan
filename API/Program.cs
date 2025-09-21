using Application;
using Domain.Ports;
using Infraestructure;
using Infraestructure.Data;
using API.Controllers.Pessoa;
using Infraestructure.ViaCep;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API",
        Version = "v1"
    });
});

builder.Services.AddPersistencia(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddHttpClient<ICepService, ViaCepService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });

    app.ApplyMigration();

    app.UseCors(x => x.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPessoaEndpoints();

app.Run();
