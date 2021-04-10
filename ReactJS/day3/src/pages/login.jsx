import React from 'react';
import { useForm } from "react-hook-form";
export function Login(){
    const { register, handleSubmit,watch } = useForm();
    const onSubmit = data => console.log(data);
    console.log(watch("example")); 
    return (
        <div>
        <div>Login</div>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label htmlFor="usernameCtrl">Username</label>
                <input type="text" id="usernameCtrl"  {...register("username",{required:true})} />
            </div>
            <div>
                <label htmlFor="passwordCtrl">Password</label>
                <input type="text" id="passwordCtrl" {...register("password",{required:true})} />
            </div>
            <div>
                <input type="submit" value="submit"/>
            </div>
        </form>
        </div>
    );
}
export default Login;