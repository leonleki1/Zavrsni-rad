    using WebApiPaulovnija.Mapping;
    using WebApiPaulovnija.Services;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<PaulovnijaContext>(opcije =>
    {
        opcije.UseSqlServer(builder.Configuration.GetConnectionString("PaulovnijaContext"));
    });

    builder.Services.AddCors(opcije =>
    {
        opcije.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
    });

    builder.Services.AddAutoMapper(typeof(MappingProfile));

    builder.Services.AddScoped<IRadnikService, RadnikService>();
    builder.Services.AddScoped<IRasadnikService, RasadnikService>();
    builder.Services.AddScoped<IStrojService, StrojService>();
    builder.Services.AddScoped<ISadnicaService, SadnicaService>();
    builder.Services.AddScoped<IZadatakService, ZadatakService>();

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
        opcije.EnableTryItOutByDefault();
    });

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseCors("CorsPolicy");

    app.MapControllers();

    app.UseStaticFiles();
    app.UseDefaultFiles();
    app.MapFallbackToFile("index.html");

    app.Run();
