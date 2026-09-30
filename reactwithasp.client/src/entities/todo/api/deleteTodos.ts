interface DeleteTodosProps {
  ids: string[];
}

export const deleteTodos = async ({ ids }: DeleteTodosProps): Promise<void> => {
  const response = await fetch(`/api/Todo/bulk`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ ids }),
  });

  if (!response.ok) {
    throw new Error("Todoの削除に失敗しました。");
  }
};
