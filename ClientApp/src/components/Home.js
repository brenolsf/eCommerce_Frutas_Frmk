import React, { Component } from 'react';
import './ObtemFrutas.css';

export class Home extends Component {
  static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { estoqueFrutas: [], loading: true };
        this.componentDidMount = this.componentDidMount.bind(this);
        this.comprarFrutas = this.comprarFrutas.bind(this);
    }

    componentDidMount() {
        this.carregaHome();
    }

    comprarFrutas() {
        alert("Adicionado ao carrinho!");
    }

    static renderHome(estoqueFrutas) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Imagem</th>
                        <th>Valor un.</th>
                        <th>Opcao</th>
                    </tr>
                </thead>
                <tbody>
                    {estoqueFrutas.map(estoqueFrutas =>
                        <tr key={estoqueFrutas.nome}>
                            <td>{estoqueFrutas.nome}</td>
                            <td><div class="container"><img src={estoqueFrutas.foto} style={{ borderRadius: '2px' }} /></div> </td>
                            <td>{estoqueFrutas.valor}</td>
                            <td><button type="submit" className="btn btn-primary" onClick={this.comprarFrutas}> <i class="fas fa-times">Comprar</i></button></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : Home.renderHome(this.state.estoqueFrutas);

        return (            
            <div>                
                <p>Bem-vindo ao E-commerce de Frutas, selecione uma das frutas abaixo e clique em comprar.</p>

                {contents}
            </div>
        );
    }

    async carregaHome() {
        const response = await fetch('api/Frutas');
        const data = await response.json();
        this.setState({ estoqueFrutas: data, loading: false });
    }
  
 }

