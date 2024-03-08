using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetworkPointsWalker.Server.Entities;
using NetworkPointsWalker.Server.Services;
using NetworkPointsWalker.Server.Services.Interfaces;
using NetworkPointsWalker.Server.ViewModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
            options.AddPolicy("DefaultCorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
        );
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseInMemoryDatabase("NetworkPointWalker"), ServiceLifetime.Singleton
);


builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ViewModelProfile>();
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

app.UseCors("DefaultCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
