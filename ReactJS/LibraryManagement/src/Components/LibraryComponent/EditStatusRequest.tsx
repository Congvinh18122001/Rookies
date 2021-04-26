import { Form, Button, Select, Table, Space, message } from "antd";
import Column from "antd/lib/table/Column";
import { useCallback } from "react";
import { useHistory, useParams } from "react-router";
import { Link } from "react-router-dom";
import { useAsync } from "../../hooks/useAsync";
import { useAuthor } from "../../hooks/useCheckAuthor";
import { getBookRequest, saveRequest } from "./cart.service";

export function EditStatusRequest() {
  const history = useHistory();
  const { isAuth } = useAuthor(1);
  if (!isAuth) {
    history.push("/unauthorized");
  }
  let { id } = useParams<any>();
  const getCallBack = useCallback(() => getBookRequest(id), [id]);
  const { value, error } = useAsync(getCallBack);
  const onFinish = (values: any) => {
    saveRequest(value.id,values.status);
    message.success("Updated !");
    history.push("/");
  };

  const onFinishFailed = (errorInfo: any) => {
    console.log("Failed:", errorInfo);
    history.push("/unauthorized");
  };
  console.log(value);
  
  return (
    <>
      <h1>Details Book</h1>
      <br />
      {error ? (
        <h1>Error !</h1>
      ) : (
        value && (
          <>
            <h3>User Name : {value.user.username}</h3>
            <h3>Book :</h3>
            {value.requestDetails && (
              <Table rowKey="id" dataSource={value.requestDetails}>
                <Column title="Book ID" render={(text, item: any) => (
                  <>
                  {item.book.id}
                  </>
                )} />
                <Column title="Book Name" render={(text, item: any) => (
                  <>
                  {item.book.name}
                  </>
                )} />
              </Table>
            )}
            <Form
              name="basic"
              initialValues={{
                status:value.status
              }}
              onFinish={onFinish}
              onFinishFailed={onFinishFailed}
            >
              <Form.Item name="status" label="Category">
                <Select>
                  <Select.Option value={0}>Pending</Select.Option>
                  <Select.Option value={1}>Approved</Select.Option>
                  <Select.Option value={2}>Rejected</Select.Option>
                </Select>
              </Form.Item>
              <Form.Item>
                <Button type="primary" htmlType="submit">
                  Save
                </Button>
              </Form.Item>
            </Form>
          </>
        )
      )}
      <Link to="/book">List Book</Link>
    </>
  );
}
