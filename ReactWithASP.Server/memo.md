# 実装手順（バックエンド）

目的：バックエンドの実装を行いつつ、実装の手順について整理し、開発の流れを復習できるようにする。

## データモデルの作成

### SQLiteとEF Coreの追加

```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### データモデルの作成

[TodoItem.cs](./Models/TodoItem.cs)

### DbContext作成

[TodoDbContext.cs](.Models/TodoContext.cs)

### Program.cs設定（DI登録）

```c
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("TodoDatabase")));

builder.Services.AddControllers();
```

`appsettings.json`に接続文字列追加

```c
{
  "ConnectionStrings": {
    "TodoDatabase": "Data Source=TodoContext.db"
  }
}
```

### マイグレーション

```bash
dotnet ef migrations add InitialCreate --project ReactWithASP.Server
dotnet ef database update --project ReactWithASP.Server
```
