import { useId, useRef } from "react";
import { useDeleteTodoMutation, type Todo } from "@/entities/todo";
import styles from "./DeleteTodoButton.module.css";

interface DeleteTodoButtonProps {
  todo: Todo;
}

export const DeleteTodoButton = ({ todo }: DeleteTodoButtonProps) => {
  const deleteTodoMutation = useDeleteTodoMutation();
  const dialogRef = useRef<HTMLDialogElement>(null);
  const titleId = useId();

  return (
    <>
      <button
        className={styles.button}
        type="button"
        aria-label={`${todo.title}を削除`}
        onClick={() => {
          deleteTodoMutation.reset();
          dialogRef.current?.showModal();
        }}
      >
        削除
      </button>
      <dialog
        ref={dialogRef}
        className={styles.dialog}
        aria-labelledby={titleId}
        onCancel={(event) => {
          if (deleteTodoMutation.isPending) {
            event.preventDefault();
          }
        }}
      >
        <h2 id={titleId} className={styles.title}>
          Todoを削除しますか？
        </h2>
        <p className={styles.message}>「{todo.title}」を削除します。この操作は取り消せません。</p>
        {deleteTodoMutation.isError && (
          <p className={styles.error} role="alert">
            {deleteTodoMutation.error.message}
          </p>
        )}
        <div className={styles.actions}>
          <button
            className={styles.cancelButton}
            type="button"
            disabled={deleteTodoMutation.isPending}
            onClick={() => dialogRef.current?.close()}
          >
            キャンセル
          </button>
          <button
            className={styles.confirmButton}
            type="button"
            disabled={deleteTodoMutation.isPending}
            onClick={() =>
              deleteTodoMutation.mutate(
                { id: todo.id },
                { onSuccess: () => dialogRef.current?.close() },
              )
            }
          >
            {deleteTodoMutation.isPending ? "削除中..." : "削除する"}
          </button>
        </div>
      </dialog>
    </>
  );
};
