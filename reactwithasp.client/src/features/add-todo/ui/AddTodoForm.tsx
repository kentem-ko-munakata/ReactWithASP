import { useAddTodoForm } from "../model/useAddTodoForm";
import styles from "./AddTodo.module.css";

export const AddTodoForm = () => {
  const { title, error, isPending, handleTitleChange, handleSubmit } = useAddTodoForm();

  return (
    <form className={styles.form} onSubmit={handleSubmit}>
      <div className={styles.controls}>
        <input
          className={styles.input}
          id="todo-title"
          type="text"
          aria-label="Todoのタイトル"
          value={title}
          onChange={handleTitleChange}
          disabled={isPending}
        />
        <button className={styles.button} type="submit" disabled={isPending}>
          {isPending ? "追加中..." : "追加"}
        </button>
      </div>
      {error && (
        <p className={styles.error} role="alert">
          {error}
        </p>
      )}
    </form>
  );
};
