import React, { Component } from 'react';

export class Carrinho extends Component {
    static displayName = Carrinho.name;

  constructor(props) {
    super(props);    
      this.fecharPedido = this.fecharPedido.bind(this);
  }

    fecharPedido() {    
        alert("Pedido realizado! Numero :" + Math.random());
  }

  render() {
    return (
      <div>
        <h1>Carrinho de comprar</h1>

        <p>Finalize o seu pedido clicando no botao abaixo.</p>
        {/*TODO - Fazer um grid exibindo os produtos do carrinho gravados no banco de dados*/}
        <button className="btn btn-primary" onClick={this.fecharPedido}>Fechar pedido</button>
      </div>
    );
  }
}
