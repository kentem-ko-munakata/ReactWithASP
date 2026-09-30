import { useDeleteTodosMutation } from "@/entities/todo";
import styles from "./DeleteTodosButton.module.css";

interface DeleteTodosButtonProps {
  ids: string[];
}

export const DeleteTodosButton = ({ ids }: DeleteTodosButtonProps) => {
  const deleteTodosMutation = useDeleteTodosMutation();
  return (
    <>
      <button
        className={styles.button}
        type="button"
        aria-label={"完了済みTodoを削除する"}
        disabled={ids.length === 0 || deleteTodosMutation.isPending}
        onClick={() => {
          const confirmed = window.confirm(
            `完了済みTodo ${ids.length} 件を削除しますか？この操作は取り消せません。`,
          );

          if (confirmed) {
            deleteTodosMutation.mutate({ ids });
          }
        }}
      >
        完了済みTodo削除
      </button>
    </>
  );
};
