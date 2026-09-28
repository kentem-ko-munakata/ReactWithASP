import { useAddTodoMutation } from "@/entities/todo";
import { useState, type ChangeEvent, type FormEvent } from "react";
import { todoTitleSchema } from "./schema";

export const useAddTodoForm = () => {
  const addTodoMutation = useAddTodoMutation();
  const [title, setTitle] = useState("");
  const [error, setError] = useState<string | null>(null);

  const handleTitleChange = (event: ChangeEvent<HTMLInputElement>) => {
    setTitle(event.target.value);
    setError(null);
  };

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const result = todoTitleSchema.safeParse(title);
    if (!result.success) {
      setError(result.error.issues[0]?.message ?? "入力内容を確認してください");
      return;
    }

    try {
      await addTodoMutation.mutateAsync({ title: result.data });
      setTitle("");
    } catch (mutationError) {
      setError(mutationError instanceof Error ? mutationError.message : "Todoの追加に失敗しました");
    }
  };

  return {
    title,
    error,
    isPending: addTodoMutation.isPending,
    handleTitleChange,
    handleSubmit,
  };
};
