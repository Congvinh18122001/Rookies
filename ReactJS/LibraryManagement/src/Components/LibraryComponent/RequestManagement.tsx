import { Space, Table } from "antd";
import Column from "antd/lib/table/Column";
import { Link } from "react-router-dom";
import { useAsync } from "../../hooks/useAsync";
import { useAuthor } from "../../hooks/useCheckAuthor";
import { IBookRequest } from "../../Models/BookRequest";
import { getBookRequests } from "./cart.service";



export function RequestManagement(){
  useAuthor(1);

    const listRequest = useAsync(getBookRequests);
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
              <Column
                render={(text, item: IBookRequest) => (
                  <Space size="middle">
                    <Link to={`/bookRequest/details/${item.id}`}>Details</Link>
                  </Space>
                )}
              />
            </Table>
          </>
        )}
      </>
    );
}