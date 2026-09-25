# 実装手順（フロントエンド）

目的：フロントエンドの実装を行いつつ、実装の手順について整理し、開発の流れを復習できるようにする。

## セットアップ

### FSDに基づいたディレクトリ構成を作成

```bash
mkdir src\app\styles
mkdir src\pages\todo
mkdir src\widgets
mkdir src\features
mkdir src\entities
mkdir src\shared
```

### cssの作成

[global.css](./src/app/styles/global.css)
[tokens.css](./src/app/styles/tokens.css)

## TodoPageの作成

- Todo型の定義
- useEffectで api/todoを呼び出し、todosにセットする
- todosを表示する
