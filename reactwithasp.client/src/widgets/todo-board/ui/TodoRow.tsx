import type { Todo } from "@/entities/todo";
import { TodoItem } from "@/entities/todo/ui/TodoItem";

interface TodoRowProps {
  todo: Todo;
}

export const TodoRow = ({ todo }: TodoRowProps) => {
  return (
    <li className="Container" key={todo.id}>
      {/* チェックボックス追加予定 */}
      <TodoItem todo={todo} />
      {/* 編集ボタン追加予定 */}
      {/* 削除ボタン追加予定 */}
    </li>
  );
};
