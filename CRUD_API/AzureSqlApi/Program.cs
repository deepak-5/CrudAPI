using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AzureSqlApi.Data;
using AzureSqlApi.Repositories;
using AzureSqlApi.CommandHandlers;
using AzureSqlApi.QueryHandlers;
using AzureSqlApi.Middleware;
using AzureSqlApi.Models;
using AzureSqlApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IRepository<Item>, Repository<Item>>();

// Services
builder.Services.AddScoped<IItemService, ItemService>();

// Command Handlers
builder.Services.AddScoped<ICreateItemCommandHandler, CreateItemCommandHandler>();
builder.Services.AddScoped<IUpdateItemCommandHandler, UpdateItemCommandHandler>();
builder.Services.AddScoped<IDeleteItemCommandHandler, DeleteItemCommandHandler>();

// Query Handlers
builder.Services.AddScoped<IGetItemQueryHandler, GetItemQueryHandler>();
builder.Services.AddScoped<IGetAllItemsQueryHandler, GetAllItemsQueryHandler>();

// Swagger/OpenAPI
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

app.UseRouting();

// Add the following line to configure authorization
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>(); // Exception handling middleware

app.MapControllers();

app.Run();
