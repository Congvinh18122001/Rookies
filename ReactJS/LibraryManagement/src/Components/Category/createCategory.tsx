import { Form, Input, Button } from "antd";
import "antd/dist/antd.css";
import { useCallback, useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useAsync } from "../../hooks/useAsync";
import { useAuthor } from "../../hooks/useCheckAuthor";
import { ICategory } from "../../Models/Category";
import { add } from "./category.service";

const layout = {
  labelCol: { span: 4 },
  wrapperCol: { span: 8 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};
export function CreateCategory() {
  const history = useHistory();
  if (!useAuthor(1)) {
    history.push("/unauthorized");
  }
  const [formData, setFormData] = useState<any>(null);
  const onFinish = (values: ICategory) => {
    setFormData(values.name);

    
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
  };
  const createCallback = useCallback(() => add(formData), [formData]);
  const createBook = useAsync(createCallback);
  useEffect(() => {
    if (createBook && createBook.status === "success") {
      history.push(`/category/details/${createBook.value.id}`);
    }
  }, [createBook, history]);
  return (
    <>
      <br />
      <h1>Create Category</h1>
      <br />
      <hr />
      <Form
        {...layout}
        name="basic"
        initialValues={{ remember: true }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        <Form.Item
          label="Name"
          name="name"
          rules={[{ required: true, message: "Please input category name!" }]}
        >
          <Input />
        </Form.Item>

        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
            Create
          </Button>
        </Form.Item>
      </Form>

    </>
  );
}
