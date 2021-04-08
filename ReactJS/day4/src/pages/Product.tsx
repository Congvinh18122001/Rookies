
import { useForm } from "react-hook-form";
import axios from "axios";
export const showProducts = ()=>{
    axios.get('http://localhost:3000/product')
      .then(function (response) {
        console.log(response.data);
      })
}

export const AddProduct = () => {

    const { register, handleSubmit } = useForm();;
    const onSubmit = (data:any) => {

        
        axios.post('http://localhost:3000/product', {
            name: data.name,
            supplier: data.supplier,
            price: data.price,
            quantity: data.quantity
          })
          .then(function () {
            showProducts();
          })
          .catch(function (error) {
            console.log(error);
          });
        
    
    }   
    return (
        <div>
        <div>AddProduct</div>
        <form onSubmit={handleSubmit(onSubmit)}>
            <div className="form-group">
                <label  htmlFor="nameCtrl">Product name : </label>
                <input className="form-control"  type="text" id="usernameCtrl"  {...register("name",{required:true})} />
            </div>
            <div className="form-group">
                <label htmlFor="supplierCtrl">Supplier : </label>
                <input className="form-control" type="text" id="supplierCtrl" {...register("supplier",{required:true})} />
            </div>
            <div className="form-group">
                <label htmlFor="priceCtrl">Price : </label>
                <input className="form-control" type="text" id="priceCtrl"  {...register("price",{required:true})} />
            </div>
            <div className="form-group">
                <label htmlFor="quantityCtrl">Quantity : </label>
                <input  className="form-control" type="text" id="quantityCtrl" {...register("quantity",{required:true})} />
            </div>
            <div className="form-group">
                <input  className="btn btn-primary" type="submit" value="Add"/>
            </div>
        </form>
        </div>
    );
}
export default AddProduct;