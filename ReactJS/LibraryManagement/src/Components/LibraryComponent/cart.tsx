import {  Button, message, Table } from "antd";
import { Content } from "antd/lib/layout/layout";
import Column from "antd/lib/table/Column";
import { useContext } from "react";
import { MyGlobalContent } from "../../Context/UseContext";
import { IBook } from "../../Models/Book";
import { sendRequest } from "./cart.service";

export function Cart(){
  const { cart, setCart } = useContext(MyGlobalContent);
    let listBookId :number[] = [];
    const  handleSentRequest = () =>{
      cart.map((book: IBook) =>{
            listBookId.push(book.id);
        });
        if(listBookId.length>0){
          sendRequest(listBookId);
          setCart([]);
          return message.success("Request success .");
        }else alert("cart is empty !");
    }
    return<>
    <Content>
      {!cart ? (
        <p>Error !!</p>
      ) : (
        <>
          <Table rowKey="id" dataSource={cart}>
            <Column title="Id" dataIndex="id" />
            <Column title="Name" dataIndex="name" />
            <Column title="Author" dataIndex="author" />
          </Table>
          <Button onClick={() => handleSentRequest()} type="primary">Sent request</Button>
        </>
      )}
    </Content>
    </>
}
