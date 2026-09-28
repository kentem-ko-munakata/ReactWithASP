using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();