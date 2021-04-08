import React from 'react';
import './App.css';
// import { Navbar } from './Components/Navbar';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Home from './pages/Home';
import Login from './pages/login';
import  Register  from './pages/Register';
import AddProduct from './pages/Product';
function App() {
  return (
    <>
     {/* <Navbar/> */}
     
     <Router>
      <div >
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
          <ul className="navbar-nav">
            <li className="nav-item ">
              <Link className="nav-link" to="/">Home</Link>
            </li>
            <li className="nav-item ">
              <Link className="nav-link" to="/Login">Login</Link>
            </li>
            <li className="nav-item ">
              <Link className="nav-link" to="/Register">Register</Link>
            </li>
            <li className="nav-item ">
              <Link className="nav-link" to="/addProduct">Add Product</Link>
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>

          <Route path="/login">
            <Login />
          </Route>
         
          <Route path="/register">
            <Register/>
          </Route>
          <Route path="/addProduct">
            <AddProduct/>
          </Route>
          <Route  path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
    </>
  );
}

export default App;
