using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Rodrigo.Rojas.Models.Exceptions;
using Rodrigo.Rojas.Models.Mappers;
using Rodrigo.Rojas.Repository.Context;
using Rodrigo.Rojas.Services;
using System.Net;

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

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature.Error;
        if (exception is NotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else if (exception is BadRequestException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        else if (exception is ConflictException)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
        await context.Response.WriteAsJsonAsync(new {Error = exception.Message});
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
