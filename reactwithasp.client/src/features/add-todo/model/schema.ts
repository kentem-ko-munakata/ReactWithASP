import z from "zod";

export const todoTitleSchema = z
  .string()
  .trim()
  .min(1, "タイトルを入力してください")
  .max(100, "タイトルは100文字以内で入力してください");
