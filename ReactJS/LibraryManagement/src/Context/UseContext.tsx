import { createContext, useContext } from "react"

export type GlobalContent = {
        token :string, 
        setToken : (c:string) => void,
        roleID :number, 
        setRoleID : (c:number) => void,
        cart:[],
        setCart : (c:[])=>void
}

export const MyGlobalContent = createContext<GlobalContent>({
    token :"",
    setToken : () => {},
    roleID:0,
    setRoleID:()=>{},
    cart:[],
    setCart :()=>{}
});

export const useGlobalContent = () => useContext(MyGlobalContent);