import { useContext } from "react";
import { Redirect } from "react-router";
import { MyGlobalContent } from "../../Context/UseContext";
import { logout } from "./Login.service"

export function Logout(){
    const {setRoleID,setToken} = useContext(MyGlobalContent);
    logout();
    setToken("");
    setRoleID(0);
    return<>
         <Redirect to="/library"/>
    </>
}