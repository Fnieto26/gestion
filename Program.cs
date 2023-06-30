using GestionTerceros.Services.CrearPersonaJuridica;
using GestionTerceros.Services.CrearPersonaNatural;
using GestionTerceros.Services.ExisteTercero;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "default",
                      policy =>
                      {
                          policy.WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS")
                                    .WithHeaders(
                                    HeaderNames.Accept,
                                    HeaderNames.ContentType,
                                    HeaderNames.Authorization)
                                    .AllowCredentials()
                                    .SetIsOriginAllowed(origin =>
                                    {
                                        if (string.IsNullOrWhiteSpace(origin)) return true;

                                        return true;
                                    });
                      });
});
builder.Services.AddTransient<IExisteTerceroService, ExisteTerceroService>();
builder.Services.AddTransient<ICrearPersonaJuridicaService, CrearPersonaJuridicaService>();
builder.Services.AddTransient<ICrearPersonaNaturalService, CrearPersonaNaturalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseAuthorization();

app.MapControllers();

app.Run();
