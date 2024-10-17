using WebApiPaulovnija.Mapping;
using WebApiPaulovnija.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodavanje kontrolera za API
builder.Services.AddControllers();

// Konfiguracija Swagger-a
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Konfiguracija konteksta baze podataka s SQL Serverom
builder.Services.AddDbContext<PaulovnijaContext>(opcije =>
{
    opcije.UseSqlServer(builder.Configuration.GetConnectionString("PaulovnijaContext"));
});

// Konfiguracija CORS-a
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

// Dodavanje AutoMapper-a za mapiranje između modela i DTO-a
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Registracija servisa
builder.Services.AddScoped<IRadnikService, IRadnikService>();
builder.Services.AddScoped<IRasadnikService, RasadnikService>();
builder.Services.AddScoped<IStrojService, StrojService>();
builder.Services.AddScoped<ISadnicaService, SadnicaService>();
builder.Services.AddScoped<IZadatakService, ZadatakService>();

var app = builder.Build();

// Konfiguracija Swagger UI
app.UseSwagger();
app.UseSwaggerUI(opcije =>
{
    opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
    opcije.EnableTryItOutByDefault();
});

// Postavljanje HTTPS preusmjeravanja
app.UseHttpsRedirection();

// Omogućavanje autorizacije
app.UseAuthorization();

// Primjena CORS politike
app.UseCors("CorsPolicy");

// Mapa kontrolera
app.MapControllers();

// Omogućavanje statičkih datoteka
app.UseStaticFiles();
app.UseDefaultFiles();

// Postavljanje fallback datoteke za SPA
app.MapFallbackToFile("index.html");

// Pokretanje aplikacije
app.Run();
