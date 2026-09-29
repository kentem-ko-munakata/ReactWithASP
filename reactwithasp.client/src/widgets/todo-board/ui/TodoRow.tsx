import type { Todo } from "@/entities/todo";
import { TodoItem } from "@/entities/todo/ui/TodoItem";
import { TodoCompletionCheckbox } from "@/features/toggle-todo";
import styles from "./TodoRow.module.css";

interface TodoRowProps {
  todo: Todo;
}

export const TodoRow = ({ todo }: TodoRowProps) => {
  return (
    <li className={`${styles.container} ${todo.isCompleted ? styles.completed : ""}`}>
      <TodoCompletionCheckbox todo={todo} />
      <TodoItem todo={todo} />
      {/* 編集ボタン追加予定 */}
      {/* 削除ボタン追加予定 */}
    </li>
  );
};
