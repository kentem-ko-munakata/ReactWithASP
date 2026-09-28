import { useTodosQuery } from "@/entities/todo";
import { TodoItem } from "@/entities/todo/ui/TodoItem";
import type { ReactNode } from "react";
import styles from "./TodoBoard.module.css";
import { AddTodoForm } from "@/features/add-todo";

export const TodoBoard = () => {
  const { data: todos, isLoading, error } = useTodosQuery();

  // 表示コンテンツ切り替え用
  let content: ReactNode;
  if (isLoading) {
    content = <p>読み込み中</p>;
  } else if (error) {
    content = <p>{error.message}</p>;
  } else if (!todos || todos.length === 0) {
    content = <p className={styles.message}>Todoはありません</p>;
  } else {
    content = (
      <ul className={styles.list}>
        {todos.map((todo) => (
          <TodoItem key={todo.id} todo={todo} />
        ))}
      </ul>
    );
  }
  return (
    <div>
      <AddTodoForm />
      {content}
    </div>
  );
};
