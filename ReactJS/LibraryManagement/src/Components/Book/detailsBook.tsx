import { useCallback } from "react";
import { useHistory, useParams } from "react-router";
import { Link } from "react-router-dom";
import { useAsync } from "../../hooks/useAsync";
import { getBook } from "./book.service";
import { useAuthor } from './../../hooks/useCheckAuthor';

export function DetailsBook() {
  const history = useHistory();
  const {isAuth} =useAuthor(1);
  if (!isAuth) {
    history.push("/unauthorized");
  }
  let { id } = useParams<any>();
  const getCallBack = useCallback(() => getBook(id), [id]);
  const { value, error } = useAsync(getCallBack);

  return (
    <>
      <h1>Details Book</h1>
      <br />
      {error ? (
        <h1>Error !</h1>
      ) : (
        value && (
          <>
            <h3>Book ID : {value.id}</h3>
            <h3>Book Name : {value.name}</h3>
            <h3>Book Author : {value.author}</h3>
            <h3>Book Category : {value.category.name}</h3>
          </>
        )
      )}
      <Link to="/book">List Book</Link>
    </>
  );
}
