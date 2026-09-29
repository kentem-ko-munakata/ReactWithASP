import { useDeleteTodoMutation, type Todo } from "@/entities/todo";
import styles from "./DeleteTodoButton.module.css";

interface DeleteTodoButtonProps {
  todo: Todo;
}

export const DeleteTodoButton = ({ todo }: DeleteTodoButtonProps) => {
  const deleteTodoMutation = useDeleteTodoMutation();

  return (
    <button
      className={styles.button}
      type="button"
      disabled={deleteTodoMutation.isPending}
      aria-label={`${todo.title}を削除`}
      onClick={() => deleteTodoMutation.mutate({ id: todo.id })}
    >
      削除
    </button>
  );
};
