import { Form, Input, Button, Checkbox, message } from "antd";
import "antd/dist/antd.css";
import { Content } from "antd/lib/layout/layout";
import React, { useCallback, useContext, useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { MyGlobalContent } from "../../Context/UseContext";
import { useAsync } from "../../hooks/useAsync";
import { login } from "./Login.service";

const layout = {
  labelCol: { span: 4 },
  wrapperCol: { span: 8 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};
export function Login() {
  const history = useHistory();
  const {setToken,setRoleID} = useContext(MyGlobalContent); 
  const [formData, setFormData] = useState<any>({username:"",password:"",});
  const loginCallback = useCallback(() =>login(formData.username, formData.password),[formData]);
  const loginData = useAsync(loginCallback);
  // const Demo = () => {
    const onFinish = (values: any) => {
       setFormData(values);
    };

    const onFinishFailed = (errorInfo: any) => {
      return message.error(" Error !")
    };
    useEffect(()=>{
          if (loginData.status==="success") {
            setToken(loginData.value.token);
            setRoleID(loginData.value.user.roleID);
            message.success(" Login Success !")
            history.push("/");
          }
    },[loginData,history]);
  return (
    <Content style={{padding:'2%'}}>
    <br/>
    <h1>Login</h1>
    <br/>
    <Form
      {...layout}
      name="basic"
      initialValues={{ remember: true }}
      onFinish={onFinish}
      onFinishFailed={onFinishFailed}
    >
      <Form.Item
        label="Username"
        name="username"
        rules={[{ required: true, message: "Please input your username!" }]}
      >
        <Input />
      </Form.Item>

      <Form.Item
        label="Password"
        name="password"
        rules={[{ required: true, message: "Please input your password!" }]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item {...tailLayout} name="remember" valuePropName="checked">
        <Checkbox>Remember me</Checkbox>
      </Form.Item>

      <Form.Item {...tailLayout}>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
</Content>
  );
}
