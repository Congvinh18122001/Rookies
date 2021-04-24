import { ICategory } from "./Category";

export interface IBook {
  id: number;
  name: string;
  author: string;
  categoryID: number;
  category: ICategory;
}
