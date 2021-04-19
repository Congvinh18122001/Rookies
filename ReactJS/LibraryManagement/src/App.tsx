import React from 'react';
import './App.css';
import { Login } from './Components/Login/Login';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import { ListCategory } from './Components/Category/listCategory';
import { ListBook } from './Components/Book/listBook';
import Layout, { Footer, Header } from 'antd/lib/layout/layout';
import Sider from 'antd/lib/layout/Sider';
import { Menu } from 'antd';
import { CreateCategory } from './Components/Category/createCategory';
import { DetailsCategory } from './Components/Category/detailsCategory';
import { CreateBook } from './Components/Book/createBook';
import { DetailsBook } from './Components/Book/detailsBook';
import { EditBook } from './Components/Book/editBook';
function App() {

  return (
    <Layout>
      <Sider></Sider>
          <Layout>

        <Router>
       <Header>
          <Menu mode="horizontal">
            <Menu.Item>
              <Link to="/">Category</Link>
            </Menu.Item>
            <Menu.Item>
              <Link to="/book">Book</Link>
            </Menu.Item>
            <Menu.Item>
              <Link to="/login">Login</Link>
            </Menu.Item>
          </Menu>
          </Header>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}

        <Switch>
          <Route path="/login">
          <Login/>
          </Route>
          <Route path="/book/details/:id">
            <DetailsBook/>
          </Route>
          <Route path="/book/edit/:id">
            <EditBook/>
          </Route>
          <Route path="/book/create">
            <CreateBook/>
          </Route>
          <Route path="/book">
            <ListBook/>
          </Route>
          
          <Route path="/category/create">
            <CreateCategory/>
          </Route>
          <Route path="/category/details/:id">
            <DetailsCategory/>
          </Route>
          <Route path="/">
            <ListCategory/>
          </Route>
          
        </Switch>
    </Router>
    </Layout>
    <Footer></Footer>
        </Layout>
  );
}

export default App;
