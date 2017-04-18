import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Root } from "./root";
import './components/index.less'
import 'material-design-lite/material.min.css';
import 'material-design-lite/material.min.js';
import { applyMiddleware } from 'redux';
import {restaurantReducer} from './reducers/restaurantReducer';
import { Provider } from 'react-redux';
import {configureStore} from './store/configureStore';

const store = configureStore();


ReactDom.render(
  <Provider store={store}>
    <Root />
  </Provider> ,
  document.getElementById('root')
);
