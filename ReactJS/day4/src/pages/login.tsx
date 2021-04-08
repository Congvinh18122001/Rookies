import axios from 'axios';
import React ,{useState} from 'react';
import { useForm } from "react-hook-form";
import 'antd/dist/antd.css';

export interface IUser{
     id:number;
     username:string;
     password:string;
}
export function Login(){
    const [ischeck,setCheck] = useState(true);
    const handleCheck = (user: IUser,listUser:IUser[])=>{
          listUser.forEach((item)=>{
              if (item.username===user.username && item.password===user.password) {
                alert("Login Success !")
                setCheck(false);
              }
          });
          if (!ischeck) {
            alert("Login fails !")
          }
          
    }
    
    const { register, handleSubmit  } = useForm();;
    const onSubmit = (data:any) =>{
        axios.get('http://localhost:3000/users')
       .then(function (response) {
           console.log(response.data);
      // handle success
       handleCheck(data,response.data);

  })
    }    
     
    return (
        <div>
        <div>Login</div>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div form-group>
                <label htmlFor="usernameCtrl">Username</label>
                <input  type="text" className="form-control" id="usernameCtrl"  {...register("username",{required:true})} />
            </div>
            <div form-group>
                <label htmlFor="passwordCtrl">Password</label>
                <input type="text" className="form-control" id="passwordCtrl" {...register("password",{required:true})} />
            </div>
            <div form-group>
                <input type="submit" className="btn btn-primary" value="Login"/>
            </div>
        </form>
        </div>
    );
}
export default Login;