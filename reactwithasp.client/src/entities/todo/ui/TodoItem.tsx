import { formatDateTimeJa } from "@/shared/lib/datetime-format";
import type { Todo } from "../model/schema";
import styles from "./TodoItem.module.css";

interface TodoItemProps {
  todo: Todo;
}
export const TodoItem = ({ todo }: TodoItemProps) => {
  return (
    <div className={`${styles.item} ${todo.isCompleted ? styles.completed : ""}`}>
      <p className={styles.title}>{todo.title}</p>
      <p>{`作成日時 : ${formatDateTimeJa(todo.createdAt)}`}</p>
      <p>{`更新日時 : ${formatDateTimeJa(todo.updatedAt)}`}</p>
    </div>
  );
};
