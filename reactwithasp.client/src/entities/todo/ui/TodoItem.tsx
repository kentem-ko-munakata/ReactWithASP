import { formatDateTimeJa } from "@/shared/lib/datetime-format";
import type { Todo } from "../model/schema";
import styles from "./TodoItem.module.css";

interface TodoItemProps {
  todo: Todo;
}
export const TodoItem = ({ todo }: TodoItemProps) => {
  return (
    <span className={`${styles.item} ${todo.isCompleted ? styles.completed : ""}`}>
      <span className={styles.title}>{todo.title}</span>
      <span>{`作成日時 : ${formatDateTimeJa(todo.createdAt)}`}</span>
      <span>{`更新日時 : ${formatDateTimeJa(todo.updatedAt)}`}</span>
    </span>
  );
};
