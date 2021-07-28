import React, { Component } from 'react';
import './ObtemFrutas.css';

export class ObtemFrutas extends Component {
  static displayName = ObtemFrutas.name;

  constructor(props) {
    super(props);
      this.state = { estoqueFrutas: [], loading: true };
  }

  componentDidMount() {
      this.carregaEstoque();
  }

 static renderEstoque(estoqueFrutas) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Nome</th>
            <th>Imagem</th>            
            <th>Valor un.</th>
          </tr>
        </thead>
        <tbody>
          {estoqueFrutas.map(estoqueFrutas =>
              <tr key={estoqueFrutas.nome}>
                  <td>{estoqueFrutas.nome}</td>
                  <td><div class="container"><img src={estoqueFrutas.foto} style={{ borderRadius: '2px' }} /></div> </td>                  
                  <td>{estoqueFrutas.valor}</td>
              </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Carregando...</em></p>
        : ObtemFrutas.renderEstoque(this.state.estoqueFrutas);

    return (
      <div>
        <h1 id="tabelLabel" >Frutas</h1>
        <p>Frutas cadastradas no momento.</p>
        {contents}
      </div>
    );
  }

  async carregaEstoque() {
    const response = await fetch('api/Frutas');
    const data = await response.json();
    this.setState({ estoqueFrutas: data, loading: false });
  }
}
