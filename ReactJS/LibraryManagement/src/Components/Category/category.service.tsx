import axios from "axios";
import { ICategory } from "../../Models/Category";

export async function add(name: string) {
  return axios
    .post("https://localhost:5001/api/Category", {
      "Name": name,
    })
    .then((res) => {
      if (res.status === 201) {
         alert("Create Success !");
         window.location.href="/";
      }else if (res.status ===204){
        alert("Category is exist!");
      }
    });
}
export async function getCategories()  {
  return await axios
    .get("https://localhost:5001/api/Category")
    .then((res) =>res.data);
}

export async function getCategory(id: ICategory) {
  return axios
    .get(`https://localhost:5001/api/Category/${id}`)
    .then((res) => res.data);
}

export async function editCategory(category: ICategory) {
  return axios
    .put(`https://localhost:5001/api/Category`, {
      "ID":category.id,
      "Name": category.name,
    })
    .then((res) => res.status);
}
export async function deleteCategory(id: ICategory) {
    return axios
      .delete(`https://localhost:5001/api/Category/${id}`)
      .then((res) => {
        if (res.status) {
          window.location.href="/";
        }
      });
  }