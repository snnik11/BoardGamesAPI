using AutoMapper;
using BoardGamesAPI.Data;
using BoardGamesAPI.Profile;
using BoardGamesAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(typeof(MappingProfile));


var mappedConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new GamesProfile());
});

IMapper mapper = mappedConfig.CreateMapper();

builder.Services.AddTransient<IGameService, GameService>();

builder.Services.AddDbContext<GameDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("GamesConnectionString")), ServiceLifetime.Singleton);

// Add services to the container.

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
