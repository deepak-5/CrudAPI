using AzureNoSql.Configuration;
using AzureNoSql.Services;
using Microsoft.Azure.Cosmos;
using AzureNoSql.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Retrieve Cosmos DB settings from configuration
var cosmosDbSettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();

// Create a CosmosClient using the settings
CosmosClient cosmosClient = new CosmosClient(cosmosDbSettings.CosmosConnectionString);
Container container = cosmosClient.GetContainer(cosmosDbSettings.DatabaseName, cosmosDbSettings.ContainerName);

// Add services to the container
builder.Services.AddSingleton(cosmosClient);
builder.Services.AddSingleton(container);

builder.Services.AddScoped<DocumentRepository>();
builder.Services.AddScoped<DocumentService>();

builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
