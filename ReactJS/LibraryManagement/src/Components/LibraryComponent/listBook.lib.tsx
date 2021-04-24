import { Table, Space, message } from "antd";
import "antd/dist/antd.css";
import Column from "antd/lib/table/Column";
import { useAsync } from "../../hooks/useAsync";
import { IBook } from "../../Models/Book";
import { getBooks } from "../Book/book.service";
import { Content } from "antd/lib/layout/layout";
import { Button } from "antd";
import { useContext } from "react";
import { MyGlobalContent } from "../../Context/UseContext";

export function Library() {
  const { value, error } = useAsync(getBooks);
  const { cart, setCart } = useContext(MyGlobalContent);

  const handleAddToCart = (book: IBook) => {
    if (cart.length < 5 && cart.length > 0) {
      let isExist = false;
      cart.map((itemCart: IBook) => {
        if (itemCart.id === book.id) {
          isExist = true;
        }
      });
      if (isExist) {
        return message.warning(" Your cart was exist item  !!");
      }
      const newCart = [...cart, book];
      setCart(newCart as any);
      return message.success("Add Success .");
    } else if (cart.length === 0) {
      const newCart = [book];
      setCart(newCart as any)
      return message.success("Add Success .");
    } else {
      return message.warning(" Your cart was full  !!");
    }
  };
  return (
    <Content>
      {error ? (
        <p>Error !!</p>
      ) : (
        <>
          <Table rowKey="id" dataSource={value}>
            <Column title="Id" dataIndex="id" />
            <Column title="Name" dataIndex="name" />
            <Column title="Author" dataIndex="author" />
            <Column
              title="Action"
              key="action"
              render={(text, item: IBook) => (
                <Space size="middle">
                  <Button type="primary" onClick={() => handleAddToCart(item)}>
                    Add To Cart
                  </Button>
                </Space>
              )}
            />
          </Table>
        </>
      )}
    </Content>
  );
}
