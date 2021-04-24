import { IBook } from "../../Models/Book";
import { deleteData ,putData,getData ,postData} from "../Services/axios.service";

export async function add(book: IBook) {
  const data ={
    Name: book.name,
    Author: book.author,
    CategoryID: book.categoryID,
  }
  return postData("https://localhost:5001/api/Books",data );
}
export async function getBooks() {
  return getData("https://localhost:5001/api/Books");
}
export async function getBook(id: IBook) {
  return getData(`https://localhost:5001/api/Books/${id}`);

}
export async function editBook(book: IBook) {
  const data = {
    ID: book.id,
    Name: book.name,
    Author: book.author,
    CategoryID: book.categoryID
  }
  return putData(`https://localhost:5001/api/Books`,data);
}
export async function deleteBook(id: IBook) {
  return deleteData(`https://localhost:5001/api/Books/${id}`);
}
