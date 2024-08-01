using Microsoft.EntityFrameworkCore;
using GessiWebApp.API.Data;
using GessiWebApp.API.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Aggiunge i servizi al container DI
builder.Services.AddControllers();

// Configurazione del database MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 23))));

// Registrazione dei servizi applicativi (business logic)
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<MovementService>();
builder.Services.AddScoped<PickingMissionService>();

// Configurazione di AutoMapper per la mappatura tra entità e DTO
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configurazione delle impostazioni per CORS se necessario
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Configurazione di Swagger per la documentazione delle API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurazione del middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Abilita CORS
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
