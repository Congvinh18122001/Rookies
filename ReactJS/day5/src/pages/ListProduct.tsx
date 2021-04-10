import axios from "axios";
import { useEffect, useState } from "react";
import React from "react";
import {
  Link,
  Redirect,
  useParams,
} from "react-router-dom";

export interface IProduct {
  id?: number;
  name: string;
  supplier: string;
  price: string;
  quantity: number;
}

//List
export function ListProduct() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState(null);
  useEffect(() => {
    (async () => {
      axios
        .get("http://localhost:5000/product")
        .then((res) => res.data)
        .then((data) => {
          setProducts(data);
        })
        .catch((err) => setError(err));
    })();
  }, []);
  return (
    <div className="container">
      <div className="row card-deck mb-3 text-center">
        <h4>List Product</h4>
        {products.map((product: IProduct) => (
          <div key={product.id} className="col-4 mb-4">
            <div className="card box-shadow">
              <Link
                to={`/Detail/${product.id}`}
              >
                <div className="card-header">
                  <h4 className="my-0 font-weight-normal">Product</h4>
                </div>

                <div className="card-body">
                  <h1 className="card-title pricing-card-title">
                    ${product.price}
                    <small className="text-muted">/ mo</small>
                  </h1>
                  <ul className="list-unstyled mt-3 mb-4">
                    <li>
                      <h2>{product.name}</h2>
                    </li>
                    <li>Supplier : {product.supplier}</li>
                    <li>Quantity : {product.quantity}</li>
                  </ul>
                  <button type="button" className="btn btn-primary">
                    Detail
                  </button>
                </div>
              </Link>
            </div>
           
          </div>
        ))}
      </div>
      {error && <p>Something went wrong!</p>}

    </div>
  );
}
//Detail
export function Detail() {
  const [isDelete,setIsDelete] = useState(false);
  let {productId} = useParams<any>();
  const [product, setProduct] = useState({
    id: 0,
    name: "error",
    supplier: "error",
    price: "error",
    quantity: 0,
  });  
  const [error, setError] = useState(null);
  useEffect(() => {
    (async () => {
      axios
        .get("http://localhost:5000/product/"+productId)
        .then((res) => res.data)
        .then((data) => {
          setProduct(data);
        })
        .catch((err) => setError(err));
    })();
  }, []);

  const handleDelete = (id: number) =>{
    axios
        .delete("http://localhost:5000/product/"+productId)
        .then((res) => {
          (res.status===200)?setIsDelete(true):alert("Delete false");
        })
  }
  return (
  <>
  {isDelete&&<Redirect to="/listProduct"/>}
  {error?<p>
    Error
    </p>:<div>
    <h3>
     productName : {product.name} <br/>
     Supplier : {product.supplier} <br/>
     Quantity : {product.quantity} <br/>
     Price : {product.price} <br/>
    </h3>
    <Link className="btn btn-primary" to={`/Edit/${productId}`}>Edit</Link>
    <button onClick={()=>handleDelete(product.id)} className="btn btn-danger">Delete</button>
    </div>
    }
  </>
  );
}
