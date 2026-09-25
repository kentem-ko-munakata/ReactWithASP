import { useEffect, useState } from "react";

export const TodoPage = () => {
  const [todos, setTodos] = useState<Todo[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    fetch("/api/Todo")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Todo一覧の取得に失敗しました。");
        }
        return response.json();
      })
      .then((data: Todo[]) => {
        setTodos(data);
      })
      .catch(() => {
        console.log("Todo一覧の取得に失敗しました。");
      })
      .finally(() => {
        setIsLoading(false);
      });
  }, []);

  return (
    <div className="todoApp">
      <h1>Todoアプリ</h1>
      {isLoading ? (
        <p>Todo一覧取得中</p>
      ) : (
        <ul className="todoList">
          {todos.map((todo) => (
            <li className="todoItem" key={todo.id}>
              {todo.title}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

type Todo = {
  id: number;
  title: string;
  isCompleted: boolean;
};
