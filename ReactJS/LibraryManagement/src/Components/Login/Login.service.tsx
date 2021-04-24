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
        localStorage.setItem("token",res.data.token);
        localStorage.setItem("userInfor",JSON.stringify(res.data.user));
        return res.data;
    });
}
export async function logout() {
  return axios
    .post("https://localhost:5001/api/logout")
    .then((res) => {
         localStorage.removeItem("token");
         localStorage.removeItem("userInfor");
    });
}

