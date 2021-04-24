import { ICategory } from "../../Models/Category";
import { deleteData, getData, postData, putData } from "../Services/axios.service";

export async function add(name: string) {
  return postData("https://localhost:5001/api/Category", {
      Name: name,
    });
;
}
export async function getCategories() {
  return getData("https://localhost:5001/api/Category");
}

export async function getCategory(id: ICategory) {
  return getData(`https://localhost:5001/api/Category/${id}`);
}

export async function editCategory(category: ICategory) {
  return putData(`https://localhost:5001/api/Category`, {
      ID: category.id,
      Name: category.name
    });
}
export async function deleteCategory(id: ICategory) {
  return deleteData(`https://localhost:5001/api/Category/${id}`);
}
