import { message } from "antd";
import { useState } from "react";

export function useAuthor(roleID:number){
    const [isAuth,setIsAuth] = useState(true)
    const a = localStorage.getItem("userInfor");
    const user = (a&&JSON.parse(a))||{roleID:0};
    if (user.roleID!==roleID) {
        message.warning("Error : Unauthorized !");
        setIsAuth(false);
    }
    return {isAuth};
}