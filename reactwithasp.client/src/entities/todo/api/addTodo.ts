import { todoSchema, type Todo } from "../model/schema";

interface AddTodoRequest {
  title: string;
}

export const addTodo = async (request: AddTodoRequest): Promise<Todo> => {
  const response = await fetch("/api/Todo", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(request),
  });

  if (!response.ok) {
    throw new Error("Todoの追加に失敗しました。");
  }

  const todo: unknown = await response.json();
  return todoSchema.parse(todo);
};
