using MovieProjectDHAUZ.Context;
using MovieProjectDHAUZ.Repository;
using MovieProjectDHAUZ.Repository.Interface;
using MovieProjectDHAUZ.Service;
using MovieProjectDHAUZ.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IMovieEntityRepository, MovieEntityRepository>();
builder.Services.AddSingleton<MovieContext>();

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
