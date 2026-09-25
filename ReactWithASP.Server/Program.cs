using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ITodoApplication, TodoApplication>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("TodoDatabase")));

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// 開発環境用
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // Swagger UI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TodoApi v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
