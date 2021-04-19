import axios from "axios";
import { IAccount } from "../../Models/Account";

// export var myHeaders = new Headers();

export async function login(username: IAccount, password: IAccount) {
  return axios
    .post("https://localhost:5001/api/Login", {
      "Username": username,
      "Password": password,
    })
    .then((res) => {
      if (res.status === 200) {
       
        alert("Login success !");
      } else {
        alert("Login error !");
      }
    });
}
export async function logout() {
  return axios
    .post("https://localhost:5001/api/logout")
    .then((res) => {
      if (res.status === 200) {
        
      }
    });
}
