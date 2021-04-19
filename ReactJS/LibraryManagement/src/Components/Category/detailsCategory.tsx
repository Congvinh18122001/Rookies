import { Button } from "antd";
import Modal from "antd/lib/modal/Modal";
import { useCallback, useEffect, useState } from "react";
import { useParams } from "react-router";
import { useAsync } from "../../hooks/useAsync";
import { deleteCategory, getCategory } from "./category.service";


export function DetailsCategory() {
    let { id } = useParams<any>();
    const [isModalVisible, setIsModalVisible] = useState(false);
    const getCallBack = useCallback(()=>getCategory(id),[id]);
    const { value, error } = useAsync(getCallBack);
    useEffect(() => {
        console.log(value);
    },[value]);
    const showModal = () => {
      setIsModalVisible(true);
    };
  
    const handleOk = () => {
        deleteCategory(id);
    };
  
    const handleCancel = () => {
      setIsModalVisible(false);
    };
    return<>
    <h1>Details Category</h1>
    <br/>
      {error?<h1>Error !</h1>:value&&<>
        <h3>Category ID : {value.id}</h3>
        <h3>Category Name : {value.name}</h3>
        <Button type="primary" onClick={showModal}>
        Delete
      </Button>
      <Modal title="Basic Modal" visible={isModalVisible} onOk={handleOk} onCancel={handleCancel}>
        <p>You want delete this category ?</p>
      </Modal>
        </>}
    </>
}