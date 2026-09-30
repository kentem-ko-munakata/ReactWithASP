import { z } from "zod";
import { todoSchema } from "../model/schema";

export const getTodos = async () => {
  const response = await fetch("/api/Todo");

  if (!response.ok) {
    throw new Error("Todo一覧の取得に失敗しました。");
  }

  const todos: unknown = await response.json();
  return z.array(todoSchema).parse(todos);
};
