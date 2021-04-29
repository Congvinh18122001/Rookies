import { message } from "antd";
import { useHistory } from "react-router-dom";

export function useAuthor(roleID:number){
    const history = useHistory();
    const a = localStorage.getItem("userInfor");
    const user = (a&&JSON.parse(a))||{roleID:0};
    if (user.roleID!==roleID) {
        message.warning("Error : Unauthorized !");
        history.push("/unauthorized");
    }
}