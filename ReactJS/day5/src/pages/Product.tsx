import { useForm } from "react-hook-form";
import axios from "axios";
import { Redirect, useParams } from "react-router-dom";
import { useEffect, useState } from "react";

export interface IProduct {
  id: number;
  name: string;
  supplier: string;
  price: string;
  quantity: number;
}

export const AddProduct = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data: IProduct) => {
    axios.post("http://localhost:5000/product", {
      name: data.name,
      supplier: data.supplier,
      price: data.price,
      quantity: data.quantity,
    });
  };
  return (
    <div className="container p-3">
      <div>AddProduct</div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="form-group">
          <label htmlFor="nameCtrl">Product name : </label>
          <input
            className="form-control"
            type="text"
            id="usernameCtrl"
            {...register("name", { required: true })}
          />
        </div>
        <div className="form-group">
          <label htmlFor="supplierCtrl">Supplier : </label>
          <input
            className="form-control"
            type="text"
            id="supplierCtrl"
            {...register("supplier", { required: true })}
          />
        </div>
        <div className="form-group">
          <label htmlFor="priceCtrl">Price : </label>
          <input
            className="form-control"
            type="text"
            id="priceCtrl"
            {...register("price", { required: true })}
          />
        </div>
        <div className="form-group">
          <label htmlFor="quantityCtrl">Quantity : </label>
          <input
            className="form-control"
            type="text"
            id="quantityCtrl"
            {...register("quantity", { required: true })}
          />
        </div>
        <div className="form-group">
          <input className="btn btn-primary" type="submit" value="Add" />
        </div>
      </form>
    </div>
  );
};
export const EditProduct = () => {
  const [error, setError] = useState(null);
  const [checkSave , setCheckSave] = useState(false);
  const [product, setProduct] = useState({
    id: 0,
    name: "error",
    supplier: "error",
    price: "error",
    quantity: 0,
  });
  const { register, handleSubmit } = useForm();
  let { productId } = useParams<any>();
  console.log(productId);

  const onSubmit = (data: IProduct) => {
    axios
      .put("http://localhost:5000/product/" + productId, {
        name: data.name,
        supplier: data.supplier,
        price: data.price,
        quantity: data.quantity,
      })
      .then((res) => {
        res.status === 200 ? setCheckSave(true): alert("Fails !");
      });
  };
  useEffect(() => {
    (async () => {
      axios
        .get("http://localhost:5000/product/" + productId)
        .then((res) => res.data)
        .then((data) => {
          setProduct(data);
          console.log(data);
        })
        .catch((err) => setError(err));
    })();
  }, []);
  return (
    <>
      {checkSave&&<Redirect to="/listProduct"/>}
      {error ? (
        <h2>Error</h2>
      ) : (
        <div className="container p-3">
          <div>AddProduct</div>
          <form onSubmit={handleSubmit(onSubmit)}>
            <div className="form-group">
              <label htmlFor="nameCtrl">Product name : </label>
              <input
                className="form-control"
                type="text"
                defaultValue={product.name}
                id="usernameCtrl"
                {...register("name", { required: true })}
              />
            </div>
            <div className="form-group">
              <label htmlFor="supplierCtrl">Supplier : </label>
              <input
                defaultValue={product.supplier}
                className="form-control"
                type="text"
                id="supplierCtrl"
                {...register("supplier", { required: true })}
              />
            </div>
            <div className="form-group">
              <label htmlFor="priceCtrl">Price : </label>
              <input
                defaultValue={product.price}
                className="form-control"
                type="text"
                id="priceCtrl"
                {...register("price", { required: true })}
              />
            </div>
            <div className="form-group">
              <label htmlFor="quantityCtrl">Quantity : </label>
              <input
                defaultValue={product.quantity}
                className="form-control"
                type="text"
                id="quantityCtrl"
                {...register("quantity", { required: true })}
              />
            </div>
            <div className="form-group">
              <input className="btn btn-primary" type="submit" value="Save" />
            </div>
          </form>
        </div>
      )}
    </>
  );
};
