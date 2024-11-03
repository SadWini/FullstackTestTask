import React from 'react';
import './App.css';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom'
import ListOrderComponent from './components/ListOrderComponent';
import HeaderComponent from './components/HeaderComponent';
import FooterComponent from './components/FooterComponent';
import CreateOrderComponent from './components/CreateOrderComponent';

function App() {
    return (
        <div>
            <Router>
                <HeaderComponent />
                <div className="container">
                    <Switch>
                        <Route path = "/" exact component = {ListOrderComponent}></Route>
                        <Route path = "/orders" component = {ListOrderComponent}></Route>
                        <Route path = "/add-order" component = {CreateOrderComponent}></Route>
                    </Switch>
                </div>
                <FooterComponent />
            </Router>
        </div>

    );
}

export default App;