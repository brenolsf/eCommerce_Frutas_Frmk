import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Cadastro } from './components/Cadastro';
import { ObtemFrutas } from './components/ObtemFrutas';
import { GerirEstoque } from './components/GerirEstoque';
import { Carrinho } from './components/Carrinho';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/cadastro-frutas' component={Cadastro} />
            <Route path='/obtem-frutas' component={ObtemFrutas} />
            <Route path='/gerir-estoque' component={GerirEstoque} />
            <Route path='/carrinho' component={Carrinho} />
        
      </Layout>
    );
  }
}
