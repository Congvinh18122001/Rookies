import { getCategories } from "./category.service";
import { Table, Space } from "antd";
import Column from "antd/lib/table/Column";
import { useAsync } from "../../hooks/useAsync";
import { Link } from "react-router-dom";
import { ICategory } from "../../Models/Category";
import { useAuthor } from "../../hooks/useCheckAuthor";
export function ListCategory() {
  const { value, error } = useAsync(getCategories);
  // const history = useHistory();
  useAuthor(1);
  return (
    <>
    <h1>Category</h1>
    <br/>
    <hr/>
    <Link to="/category/create">Create Category</Link>
      {error ? (
        <p>Error !!</p>
      ) : (
        <Table rowKey ="id" dataSource={value}>
          <Column title="Id" dataIndex="id" />
          <Column title="Name" dataIndex="name"/>
          <Column
            title="Action"
            key="action"
            render={(text, item:ICategory) => (
              <Space size="middle">
               <Link to={`/category/details/${item.id}`}>Details</Link>
               <Link to={`/category/edit/${item.id}`}>Edit</Link>
               {/* <Link to={`/category/delete/${item.id}`}>Delete</Link> */}
              </Space>
            )}
          />
        </Table>
      )}
    </>
  );
}
