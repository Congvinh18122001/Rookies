import { Select, Form, Input, Button } from "antd";
import { useAsync } from "../../hooks/useAsync";
import { IBook } from "../../Models/Book";
import { editBook, getBook } from "./book.service";
import { getCategories } from "../Category/category.service";
import { ICategory } from "../../Models/Category";
import { useHistory, useParams } from "react-router";
import { useCallback, useEffect, useState } from "react";
import { useAuthor } from "../../hooks/useCheckAuthor";

const layout = {
  labelCol: { span: 4 },
  wrapperCol: { span: 8 },
};
const tailLayout = {
  wrapperCol: { offset: 8, span: 16 },
};
export function EditBook() {
  const history = useHistory();
  useAuthor(1);

  const [formData, setFormData] = useState<any>(null);
  let { id } = useParams<any>();
  const categories = useAsync(getCategories);
  const getBookCallback = useCallback(() => getBook(id), [id]);
  const book = useAsync(getBookCallback);
  const onFinish = (values: IBook) => {
    setFormData(values);
    
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
  };
  const editCallback = useCallback(() => editBook(formData), [formData]);
  const { value, error } = useAsync(editCallback);
  useEffect(() => {
    if (!error && value) {
      history.push(`/book/details/${id}`);
    }
  }, [value, error, id, history]);
  return (
    <>
      <h1>Edit Book</h1>
      <br />
      {book.value != null && (
        <Form
          {...layout}
          name="basic"
          initialValues={{
            id: book.value.id,
            name: book.value.name,
            author: book.value.author,
            categoryID: book.value.categoryID,
          }}
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
        >
          <Form.Item name="id">
            <Input hidden />
          </Form.Item>
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
              {!categories.error &&
                categories.value &&
                categories.value.map((item: ICategory) => (
                  <Select.Option key={item.id} value={item.id}>
                    {item.name}
                  </Select.Option>
                ))}
            </Select>
          </Form.Item>
          <Form.Item {...tailLayout}>
            <Button type="primary" htmlType="submit">
              Save
            </Button>
          </Form.Item>
        </Form>
      )}
    </>
  );
}
