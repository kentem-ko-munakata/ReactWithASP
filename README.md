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

```bash
dotnet add package Swashbuckle.AspNetCore.SwaggerUI
dotnet add package Swashbuckle.AspNetCore
```

②`Program.cs`を設定
[Program.cs](ReactWithASP.Server/Program.cs)

[\*.csproj](ReactWithASP.Server/ReactWithASP.Server.csproj)

③デバッグ実行し、以下にアクセス

```bash
https://localhost:7143/swagger/index.html
```
