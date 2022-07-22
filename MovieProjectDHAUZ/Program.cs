using MovieProjectDHAUZ.Context;
using MovieProjectDHAUZ.DTOs.Configuration;
using MovieProjectDHAUZ.Repository;
using MovieProjectDHAUZ.Repository.Interface;
using MovieProjectDHAUZ.Service;
using MovieProjectDHAUZ.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IMovieEntityRepository, MovieEntityRepository>();
builder.Services.AddSingleton<MovieContext>();
builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.Development.json", true, true);

builder.Services.AddSingleton<ConfigurationDto>(provider => builder.Configuration.Get<ConfigurationDto>());
builder.Services.AddScoped(provider =>
{
    var config = builder.Configuration.Get<ConfigurationDto>();
    return new MovieContext(config);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
