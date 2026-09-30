import { todoSchema, type Todo } from "../model/schema";

interface ToggleTodoProps {
  id: string;
}

export const toggleTodo = async ({ id }: ToggleTodoProps): Promise<Todo> => {
  const response = await fetch(`/api/Todo/${id}/toggle`, {
    method: "POST",
  });

  if (!response.ok) {
    throw new Error("Todoの更新に失敗しました。");
  }

  const todo: unknown = await response.json();
  return todoSchema.parse(todo);
};
