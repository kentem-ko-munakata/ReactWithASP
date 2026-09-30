using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ReactWithASP.Server.Models;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Repositories;

// アプリの設定を読み込み、サービス登録を行うためのビルダーを作成
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

// DIコンテナ登録
builder.Services.AddScoped<ITodoApplication, TodoApplication>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// EFCoreのDbContext登録（SQLite）
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("TodoDatabase")));

// Swagger用
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// 登録した設定をもとにWebアプリを構築
var app = builder.Build();

app.UseExceptionHandler();

app.UseDefaultFiles();
app.MapStaticAssets();

// 開発環境ではAPI仕様書とSwagger UIを公開
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

// APIなど他のルートに一致しないアクセスは、フロントエンドのindex.htmlへ返却
app.MapFallbackToFile("/index.html");
app.Run();