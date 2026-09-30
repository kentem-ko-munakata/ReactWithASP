interface DeleteTodoProps {
  id: number;
}

export const deleteTodo = async ({ id }: DeleteTodoProps): Promise<void> => {
  const response = await fetch(`/api/Todo/${id}`, {
    method: "DELETE",
  });

  if (!response.ok) {
    throw new Error("Todoの削除に失敗しました。");
  }
};
