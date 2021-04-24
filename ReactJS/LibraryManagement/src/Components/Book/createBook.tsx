import { Select, Form, Input, Button } from "antd";
import { useAsync } from "../../hooks/useAsync";
import { IBook } from "../../Models/Book";
import { add } from "./book.service";
import { getCategories } from "../Category/category.service";
import { ICategory } from "../../Models/Category";
import { useCallback, useEffect, useState } from "react";
import { useHistory } from "react-router";
import { useAuthor } from "../../hooks/useCheckAuthor";

const layout = {
  labelCol: { span: 4 },
  wrapperCol: { span: 8 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};
export function CreateBook() {
  const history = useHistory();
  const {isAuth} =useAuthor(1);
  if (!isAuth) {
    history.push("/unauthorized");
  }
  const [formData, setFormData] = useState<any>(null);
  const { value, error } = useAsync(getCategories);

  const onFinish = (values: IBook) => {
    setFormData(values);
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
  };
  const createCallback = useCallback(() => add(formData), [formData]);
  const createBook = useAsync(createCallback);
  useEffect(() => {
    if (createBook && createBook.status === "success") {
      history.push(`/book/details/${createBook.value.id}`);
    }
  }, [createBook, history]);
  return (
    <>
      <h1>Create Book</h1>
      <br />
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
          rules={[{ required: true, message: "Please input book name!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          label="Author"
          name="author"
          rules={[{ required: true, message: "Please input book author!" }]}
        >
          <Input />
        </Form.Item>
        <Form.Item name="categoryID" label="Category">
          <Select>
            {!error &&
              value &&
              value.map((item: ICategory) => (
                <Select.Option key={item.id} value={item.id}>
                  {item.name}
                </Select.Option>
              ))}
          </Select>
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
