import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Root } from "./root";
import './components/index.less'
import 'jquery';
// import 'bootstrap/dist/js/bootstrap.min.js';
// import 'bootstrap/dist/css/bootstrap.min.css';
import 'material-design-lite/material.min.css';
import 'material-design-lite/material.min.js';

ReactDom.render(
  <Root /> ,
  document.getElementById('root')
);