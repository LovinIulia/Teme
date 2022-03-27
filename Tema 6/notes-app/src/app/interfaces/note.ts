import { Category } from "./category";
export interface Note {
    id: string;
    title: string;
    description: string;
    category: Category;
}
