using AStarCrawler.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetworkPointsWalker.Server.DTO;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Models;
using NetworkPointsWalker.Server.Services;
using NetworkPointsWalker.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("NetworkPointWalker")
);


builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IGraphService, GraphService>();
builder.Services.AddScoped<IOCPService, OCPService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<IAStarCrawler, AStarCrawler.AStarCrawler>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<DTOProfile>();
    cfg.AddProfile<ModelProfile>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
