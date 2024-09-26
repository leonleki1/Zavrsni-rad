using WebApiPaulovnija;
using Microsoft.EntityFrameworkCore;
using WebApiPaulovnija.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Paulovnijacontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Paulovnijacontext"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
    options.EnableTryItOutByDefault();
});

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.UseDefaultFiles();
app.MapFallbackToFile("index.html");

app.Run();
