import * as React from 'react';
import { Header } from './components/header';
import { Router, Route, BrowserRouter } from 'react-router-dom';
import { createBrowserHistory } from 'history';
import { Home } from './home';
import  AddRestaurant  from './components/restaurants';

interface RootProps {
    test?: string;
}
export class Root extends React.Component<RootProps, {}>{

    public restos: string[] = [];

    render() {
        var browserhistory = createBrowserHistory();
        return (
            <BrowserRouter >
                <div className="mdl-layout mdl-js-layout mdl-layout--fixed-header">
                    <Header />
                    <div className="container">
                        <Route exact path="/" component={Home} />
                        <Route exact path="/restaurants" render={() => (
                            <AddRestaurant />)} />
                    </div>
                </div>
            </BrowserRouter>
        );
    }
}