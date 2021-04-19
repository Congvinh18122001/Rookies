

import { useCallback } from "react";
import { useParams } from "react-router";
import { Link } from "react-router-dom";
import { useAsync } from "../../hooks/useAsync";
import {  getBook } from "./book.service";


export function DetailsBook() {
    let { id } = useParams<any>();
    const getCallBack = useCallback(()=>getBook(id),[id]);
    const { value, error } = useAsync(getCallBack);

    return<>
    <h1>Details Category</h1>
    <br/>
      {error?<h1>Error !</h1>:value&&<>
        <h3>Book ID     : {value.id}</h3>
        <h3>Book Name   : {value.name}</h3>
        <h3>Book Author : {value.author}</h3>
        </>}
        <Link to="/book">List Book</Link>
    </>
}