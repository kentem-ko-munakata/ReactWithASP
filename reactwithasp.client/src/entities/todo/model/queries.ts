import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getTodos } from "../api/getTodos";
import { addTodo } from "../api/addTodo";
import type { Todo } from "./schema";

export const todoKeys = {
  list: ["todos"] as const,
};

export const useTodosQuery = () => {
  return useQuery({
    queryKey: todoKeys.list,
    queryFn: getTodos,
  });
};

export const useAddTodoMutation = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: addTodo,
    onSuccess: (created) => {
      queryClient.setQueryData<Todo[]>(todoKeys.list, (old) =>
        old ? [created, ...old] : [created],
      );
    },
  });
};
