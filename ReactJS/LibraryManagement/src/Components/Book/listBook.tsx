import { Table, Space } from "antd";
import "antd/dist/antd.css";
import Column from "antd/lib/table/Column";
import { useAsync } from "../../hooks/useAsync";
import { Link, useHistory } from "react-router-dom";
import { IBook } from "../../Models/Book";
import { deleteBook, getBooks } from "./book.service";
import { Content } from "antd/lib/layout/layout";
import { useCallback, useEffect, useState } from "react";
import { Modal, Button } from "antd";
import { useAuthor } from "../../hooks/useCheckAuthor";

export function ListBook() {
  const history = useHistory();
  const {isAuth} =useAuthor(1);
  if (!isAuth) {
    history.push("/unauthorized");
  }
  const { value, error } = useAsync(getBooks);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [id, setId] = useState<any>();
  const [deleteId, setDeleteId] = useState<any>();
  const showModal = () => {
    setIsModalVisible(true);
  };
  const handleID = (id: number) => {
    setId(id);
    showModal();
  };
  const handleOk = () => {
    setDeleteId(id);
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  const deleteCallback = useCallback(() => deleteBook(deleteId), [deleteId]);
  const { status } = useAsync(deleteCallback);
  useEffect(() => {
    if (status === "success") {
      history.push("/book");
    }
  }, [status, history]);
  return (
    <Content>
      {error ? (
        <p>Error !!</p>
      ) : (
        <>
          <Link to="/book/create">Create Book</Link>
          <Table rowKey="id" dataSource={value}>
            <Column title="Id" dataIndex="id" />
            <Column title="Name" dataIndex="name" />
            <Column title="Author" dataIndex="author" />
            <Column
              title="Action"
              key="action"
              render={(text, item: IBook) => (
                <Space size="middle">
                  <Link to={`/book/details/${item.id}`}>Details</Link>
                  <Link to={`/book/edit/${item.id}`}>Edit</Link>
                  <Button type="primary" onClick={() => handleID(item.id)}>
                    Delete
                  </Button>
                  <Modal
                    title="Basic Modal"
                    visible={isModalVisible}
                    onOk={handleOk}
                    onCancel={handleCancel}
                  >
                    <p>You want delete this book ?</p>
                    <p>Name : {item.name} </p>
                    <p>Author : {item.author}</p>
                  </Modal>
                </Space>
              )}
            />
          </Table>
        </>
      )}
    </Content>
  );
}
