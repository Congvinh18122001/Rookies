import React, { useState } from "react";
import "./App.css";
import { Login } from "./Components/Login/Login";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { ListCategory } from "./Components/Category/listCategory";
import { ListBook } from "./Components/Book/listBook";
import Layout, { Footer, Header } from "antd/lib/layout/layout";
import {  Menu } from "antd";
import { CreateCategory } from "./Components/Category/createCategory";
import { DetailsCategory } from "./Components/Category/detailsCategory";
import { CreateBook } from "./Components/Book/createBook";
import { DetailsBook } from "./Components/Book/detailsBook";
import { EditBook } from "./Components/Book/editBook";
import { Library } from "./Components/LibraryComponent/listBook.lib";
import { Cart } from "./Components/LibraryComponent/cart";
import { RequestHistory } from "./Components/LibraryComponent/RequestHistory";
import { RequestManagement } from "./Components/LibraryComponent/RequestManagement";
import { MyGlobalContent } from "./Context/UseContext";
import { Logout } from "./Components/Login/Logout";
import { Unauthorized } from "./Components/Error/UnAuthorized";
import { EditStatusRequest } from "./Components/LibraryComponent/EditStatusRequest";
function App() {
  const [token, setToken] = useState(localStorage.getItem("token") || "");
  const [cart, setCart] = useState([] as any);
  const a = localStorage.getItem("userInfor");
  const user = (a && JSON.parse(a)) || { roleID: 0 };
  const [roleID, setRoleID] = useState(user.roleID);

  console.log(token);

  return (
    <MyGlobalContent.Provider
      value={{ token, setToken, roleID, setRoleID, cart, setCart }}
    >
      <Layout>
        <Router>
          <Header style={{ padding: 0 }}>
            <Menu mode="horizontal">
              <Menu.Item>
                <Link to="/library">Library</Link>
              </Menu.Item>
              {roleID === 1 && (
                <>
                  <Menu.Item>
                    <Link to="/">Category</Link>
                  </Menu.Item>
                  <Menu.Item>
                    <Link to="/book">Book</Link>
                  </Menu.Item>
                  <Menu.Item>
                    <Link to="/requestManagement"> Management Request </Link>
                  </Menu.Item>
                </>
              )}

              {roleID === 2 && (
                <>
                  <Menu.Item>
                    <Link to="/cart">Cart</Link>
                  </Menu.Item>
                  <Menu.Item>
                    <Link to="/RequestHistory"> History Request </Link>
                  </Menu.Item>
                </>
              )}

              <Menu.Item>
                {token !== "" ? (
                  <Link to="/logout">Logout</Link>
                ) : (
                  <Link to="/login">Login</Link>
                )}
              </Menu.Item>
            </Menu>
          </Header>
          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}

          <Switch>
            <Route path="/RequestHistory">
              <RequestHistory />
            </Route>
            <Route path="/cart">
              <Cart />
            </Route>
            <Route path="/library">
              <Library />
            </Route>
            <Route path="/logout">
              <Logout />
            </Route>
            <Route path="/login">
              <Login />
            </Route>
            <Route path="/book/details/:id">
              <DetailsBook />
            </Route>
            <Route path="/book/edit/:id">
              <EditBook />
            </Route>
            <Route path="/book/create">
              <CreateBook />
            </Route>
            <Route path="/book">
              <ListBook />
            </Route>
            <Route path="/category/create">
              <CreateCategory />
            </Route>
            <Route path="/category/details/:id">
              <DetailsCategory />
            </Route>
            <Route path="/requestManagement">
              <RequestManagement />
            </Route>
            <Route path="/bookRequest/details/:id">
              <EditStatusRequest/>
            </Route>
            <Route path="/unauthorized">
              <Unauthorized />
            </Route>
            <Route path="/">
              <ListCategory />
            </Route>
          </Switch>
        </Router>
        <Footer></Footer>
      </Layout>
    </MyGlobalContent.Provider>
  );
}

export default App;
