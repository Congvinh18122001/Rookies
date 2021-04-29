import { getData, postData, putData } from "../Services/axios.service";

export function sendRequest(listBookId:number[]){
    const a = localStorage.getItem("userInfor");
    if (!a) {
        alert("you need login to send request !");
        return false;
    }
    const  user = a&&JSON.parse(a);
    
    const data = {
        ListBookID:listBookId,
        UserID:user.id
    }
    postData("https://localhost:5001/api/Borrowings/RequestBook",data );
    return true; 
}
export async function getBookRequests() {
    return getData(`https://localhost:5001/api/Borrowings`);
}
export async function getBookRequest(id:number) {
    return getData(`https://localhost:5001/api/Borrowings/${id}`);
}
export async function getBookRequestsByUser() {
    const a = localStorage.getItem("userInfor");
    const token = localStorage.getItem("token");

    if (!a||!token) {
        alert("you need login to send request !");
        return null;
    }
    const  user = a&&JSON.parse(a);
    return getData(`https://localhost:5001/api/Borrowings/User/${user.id}`);
}

export function saveRequest(requestID:number,status:number){
    
    const data = {
        ID:requestID,
        Status:status
    }
    putData("https://localhost:5001/api/Borrowings",data );
}