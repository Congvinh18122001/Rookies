import { useForm } from "react-hook-form";
import axios from "axios";
import 'antd/dist/antd.css';



export const Register = () => {

    const { register, handleSubmit } = useForm();;
    const onSubmit = (data:any) => {

        
        axios.post('http://localhost:3000/users', {
            username: data.username,
            password: data.password
          })
          .then(function (response) {
            console.log(response);
          })
          .catch(function (error) {
            console.log(error);
          });
    }   
    return (
        <div>
        <div>Register</div>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div className="form-group">
                <label htmlFor="usernameCtrl">Username</label>
                <input className="form-control" type="text" id="usernameCtrl"  {...register("username",{required:true})} />
            </div>
            <div className="form-group">
                <label htmlFor="passwordCtrl">Password</label>
                <input className="form-control" type="text" id="passwordCtrl" {...register("password",{required:true})} />
            </div>
            <div className="form-group">
                <input className="btn btn-primary" type="submit" value="register"/>
            </div>
        </form>
        </div>
    );
}

export default Register;