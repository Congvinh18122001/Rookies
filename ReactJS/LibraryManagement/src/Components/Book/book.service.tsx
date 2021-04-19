import axios from "axios";
import { IBook } from "../../Models/Book";

export async function add(book: IBook) {
  return axios
    .post("https://localhost:5001/api/Books", {
        "Name": book.name,
        "Author":book.author,
        "CategoryID": book.categoryID
    })
    .then((res) => {
      if (res.status===201) {
        window.location.href="/book";
      }
    });
}
export async function getBooks()  {
  return await axios
    .get("https://localhost:5001/api/Books")
    .then((res) =>res.data);
}
export async function getBook(id: IBook) {
  return axios
    .get(`https://localhost:5001/api/Books/${id}`)
    .then((res) => res.data);
}
export async function editBook(book: IBook) {
  return axios
    .put(`https://localhost:5001/api/Books`, {
        "ID": book.id,
      "Name": book.name,
      "Author":book.author,
      "CategoryID": book.categoryID
    })
    .then((res) => res.status);
}
export async function deleteBook(id: IBook) {
    return axios
      .delete(`https://localhost:5001/api/Books/${id}`)
      .then((res) => { if (res.status===200) {
        window.location.href="/book";
      }});
  }