import { useToggleTodoMutation, type Todo } from "@/entities/todo";
import styles from "./TodoCompletionCheckbox.module.css";

interface TodoCompletionCheckboxProps {
  todo: Todo;
}

export const TodoCompletionCheckbox = ({ todo }: TodoCompletionCheckboxProps) => {
  const toggleTodoMutation = useToggleTodoMutation();

  return (
    <>
      <input
        className={styles.checkbox}
        type="checkbox"
        checked={todo.isCompleted}
        disabled={toggleTodoMutation.isPending}
        aria-label={`${todo.title}を${todo.isCompleted ? "未完了" : "完了"}にする`}
        onChange={() => toggleTodoMutation.mutate({ id: todo.id })}
      />
    </>
  );
};
