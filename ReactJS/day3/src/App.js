import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import {LineChart} from './Components/line-chart.jsx';
import Home from './pages/Home';
import { Profile } from './pages/Profile';
// import { Product } from './pages/product';
import { Login } from './pages/login';
function App() {
  return (
    <Router>
    <div>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/profile">Profile</Link>
          </li>
          {/* <li>
            <Link to="/product">Product</Link>
          </li> */}
          <li>
            <Link to="/login">Login</Link>
          </li>
        </ul>
      </nav>

      {/* A <Switch> looks through its children <Route>s and
          renders the first one that matches the current URL. */}
      <Switch>
        <Route path="/">
          <Home />
        </Route>
        <Route path="/profile">
          <Profile />
        </Route>
        {/* <Route path="/product">
          <Product />
        </Route> */}
        <Route path="/login">
             <Login/>
        </Route>
      </Switch>
    </div>
  </Router>
  );
}

export default App;
