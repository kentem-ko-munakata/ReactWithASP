# ReactWithASP
React × ASP.NET Coreの基礎を学ぶために作成する、研修用のTodo管理アプリです。

## 主な機能
- タスク一覧表示
- タスクの追加
- タスクの完了状態切り替え
- タスクの更新
- タスクの削除
- 完了済みタスクの一括削除

## メモ
### SwaggerUIの追加手順
①ASP.NET Coreプロジェクト配下にて以下コマンドを実行し`Swagger UIパッケージ`を追加
```powershell
dotnet add package Swashbuckle.AspNetCore.SwaggerUI
```
②`Program.cs`を設定
```diff
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

+    // Swagger UI
+    app.UseSwaggerUI(options =>
+    {
+        options.SwaggerEndpoint("/openapi/v1.json", "TodoApi v1");
+    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

```
③デバッグ実行し、以下にアクセス
```bash
https://localhost:7143/swagger/index.html
```