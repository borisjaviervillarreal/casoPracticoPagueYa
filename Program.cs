using CobranzasApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de servicios y repositorios personalizados
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IIntencionPagoService, IntencionPagoService>();
builder.Services.AddScoped<IDatosParametricasService, DatosParametricasService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); 

app.UseCors("Nueva Politica");

app.UseAuthorization();

app.MapControllers();

app.Run();
