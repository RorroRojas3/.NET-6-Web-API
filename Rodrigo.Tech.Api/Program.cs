using Microsoft.EntityFrameworkCore;
using Rodrigo.Rojas.Models.Mappers;
using Rodrigo.Rojas.Repository.Context;
using Rodrigo.Rojas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoContext>(options =>
    options.UseInMemoryDatabase(nameof(DemoContext)));
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddAutoMapper(typeof(Mappers));

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