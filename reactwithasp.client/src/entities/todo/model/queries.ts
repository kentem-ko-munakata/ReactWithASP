import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { getTodos } from "../api/getTodos";
import { addTodo } from "../api/addTodo";
import type { Todo } from "./schema";
import { toggleTodo } from "../api/toggleTodo";

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
      // 新しく作成した Todo を一覧キャッシュの先頭に追加する。
      queryClient.setQueryData<Todo[]>(todoKeys.list, (old) =>
        old ? [created, ...old] : [created],
      );
    },
  });
};

export const useToggleTodoMutation = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: toggleTodo,
    onSuccess: (updated) => {
      queryClient.setQueryData<Todo[]>(todoKeys.list, (old) => {
        // 一覧キャッシュがなければ、更新結果で初期化する。
        if (!old) {
          return [updated];
        }

        // 既存項目は ID で置き換え、見つからない場合は一覧に追加する。
        return old.some((todo) => todo.id === updated.id)
          ? old.map((todo) => (todo.id === updated.id ? updated : todo))
          : [updated, ...old];
      });
    },
  });
};
