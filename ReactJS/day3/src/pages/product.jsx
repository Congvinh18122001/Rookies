import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    useRouteMatch,
    useParams
  } from "react-router-dom";
export function Product() {
  let match = useRouteMatch();
  return (
    <div>
      product
      <ul>
        <li>
          <Link to={`${match.url}/10`}>Components</Link>
        </li>
        <li>
          <Link to={`${match.url}/20`}>Props v. State</Link>
        </li>
      </ul>
      <Switch>
        <Route path={`${match.path}/:topicId`}>
          <Topic />
        </Route>
        <Route path={match.path}>
          <h3>Please select a topic.</h3>
        </Route>
      </Switch>
    </div>
  );
}

function Topic() {
    let { topicId } = useParams();
    return <h3>Requested topic ID: {topicId}</h3>;
  }
