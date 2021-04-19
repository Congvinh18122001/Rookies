
import { Select,Form, Input, Button } from 'antd';
import { useAsync } from '../../hooks/useAsync';
import { IBook } from '../../Models/Book';
import { add, getBook } from './book.service';
import {  getCategories } from "../Category/category.service";
import { ICategory } from '../../Models/Category';
import { useParams } from 'react-router';

const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 8 },
  };
  const tailLayout = {
    wrapperCol: { offset: 8, span: 16 },
  };
export function EditBook(){
    let { id } = useParams<any>();
    const  categories = useAsync(getCategories);
    const book = useAsync(getBook(id));
    const onFinish = (values: IBook) => {
        add(values);
      };
    
      const onFinishFailed = (errorInfo: any) => {
        console.log("Failed:", errorInfo);
      };
    return<>
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
            {!categories.error&&categories.value&&categories.value.map((item:ICategory)=><Select.Option value={item.id}>{item.name}</Select.Option>)}
          </Select>
        </Form.Item>
        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
            Create
          </Button>
        </Form.Item>
      </Form>
    </>
}