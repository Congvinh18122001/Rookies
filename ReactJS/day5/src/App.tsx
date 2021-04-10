import React from "react";
import "./App.css";
// import { Navbar } from './Components/Navbar';
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Home from "./pages/Home";
import { AddProduct, EditProduct } from "./pages/Product";
import { Detail, ListProduct } from "./pages/ListProduct";
function App() {
  return (
    <>
      {/* <Navbar/> */}

      <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <ul className="navbar-nav">
              <li className="nav-item ">
                <Link className="nav-link" to="/">
                  Home
                </Link>
              </li>
              <li className="nav-item ">
                <Link className="nav-link" to="/addProduct">
                  Add Product
                </Link>
              </li>
              <li className="nav-item ">
                <Link className="nav-link" to="/listProduct">
                  List Product
                </Link>
              </li>
            </ul>
          </nav>

          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
          <Switch>
            <Route path="/addProduct">
              <AddProduct />
            </Route>
            <Route path={"/Detail/:productId"}>
              <Detail />
            </Route>
            <Route path={"/Detail/"}>
            <ListProduct />
            </Route>
            <Route path="/Edit/:productId">
              <EditProduct />
            </Route>
            <Route path="/listProduct">
              <ListProduct />
            </Route>
            <Route path="/">
              <Home />
            </Route>
          </Switch>
        </div>
      </Router>
    </>
  );
}

export default App;
