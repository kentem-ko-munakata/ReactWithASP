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

## TODO一覧取得API作成

### Controller層作成

[TodoController.cs](./Controllers/)

```c
using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(): ControllerBase
{
  [HttpGet]
  public void GetTodos()
  {
    Console.WriteLine("GET: api/todoが呼ばれました");
  }
}
```

### Repository層作成

[ITodoRepository.cs](./Repositories/ITodoRepository.cs)
[TodoRepository.cs](./Repositories/TodoRepository.cs)

### App層作成

[ITodoApplication.cs](./Application/ITodoApplication.cs)
[TodoApplication.cs](./Application/TodoApplication.cs)

### Controller更新

アプリ層のインターフェースを受け取り、GetTodos(Todo一覧取得)を呼び出すAPI作成

```c
using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoApplication application) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<TodoItem>>> GetTodos()
  {
    var todos = await application.GetTodos();
    return Ok(todos);
  }
}
```

### DI登録

[Program.cs](./Program.cs)

```c
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Repositories;

builder.Services.AddScoped<ITodoApplication, TodoApplication>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
```
