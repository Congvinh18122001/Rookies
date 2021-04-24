import {  Table } from "antd";
import Column from "antd/lib/table/Column";
import {  useHistory } from "react-router-dom";
import { useAsync } from "../../hooks/useAsync";
import { useAuthor } from "../../hooks/useCheckAuthor";
import { IBookRequest } from "../../Models/BookRequest";

import { getBookRequestsByUser } from "./cart.service";

export function RequestHistory() {
  const history = useHistory();
  const {isAuth} =useAuthor(2);
  if (!isAuth) {
    history.push("/login");
  }
  const listRequest = useAsync(getBookRequestsByUser);
  listRequest && console.log(listRequest.value);

  return (
    <>
      {!listRequest.error && listRequest.value && (
        <>
          <Table rowKey="id" dataSource={listRequest.value}>
            <Column title="Id" dataIndex="id" />
            <Column title="Status" render={(text, item: IBookRequest) => (
                <>
                
                 {item.status===0&&<span>Pending</span>}
                 {item.status===1&&<span>Approved</span>}
                 {item.status===2&&<span>Rejected</span>}
                </>
              )} />
            <Column title="Time" dataIndex="requestAt"/>
          </Table>
        </>
      )}
    </>
  );
}
