import { useQuery } from "@tanstack/react-query";
import { getTodos } from "../api/getTodos";

export const todoKeys = {
  list: ["todos"] as const,
};

export const useTodosQuery = () => {
  return useQuery({
    queryKey: todoKeys.list,
    queryFn: getTodos,
  });
};
