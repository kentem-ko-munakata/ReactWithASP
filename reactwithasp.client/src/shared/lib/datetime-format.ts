// src/lib/date.ts
import dayjs from "dayjs";

export const formatDateTimeJa = (date: string | Date) => dayjs(date).format("YYYY/MM/DD HH:mm");

export const formatDateJa = (date: string | Date) => dayjs(date).format("YYYY/MM/DD");
