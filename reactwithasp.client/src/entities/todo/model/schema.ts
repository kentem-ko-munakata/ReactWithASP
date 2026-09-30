import { z } from "zod";

export const todoSchema = z.object({
  id: z.int(),
  title: z.string(),
  isCompleted: z.boolean(),
  createdAt: z.iso.datetime({ offset: true }),
  updatedAt: z.iso.datetime({ offset: true }),
});

export type Todo = z.infer<typeof todoSchema>;
