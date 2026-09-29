import type { Todo } from "@/entities/todo";
import { TodoItem } from "@/entities/todo/ui/TodoItem";
import { TodoCompletionCheckbox } from "@/features/toggle-todo";
import styles from "./TodoRow.module.css";
import { DeleteTodoButton } from "@/features/delete-todo";

interface TodoRowProps {
  todo: Todo;
}

export const TodoRow = ({ todo }: TodoRowProps) => {
  return (
    <li className={`${styles.container} ${todo.isCompleted ? styles.completed : ""}`}>
      <label className={styles.toggleArea}>
        <TodoCompletionCheckbox todo={todo} />
        <TodoItem todo={todo} />
      </label>
      {/* 編集ボタン追加予定 */}
      <DeleteTodoButton todo={todo} />
    </li>
  );
};
