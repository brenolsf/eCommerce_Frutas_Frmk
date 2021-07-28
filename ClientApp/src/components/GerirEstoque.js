import React, { Component } from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';


export class GerirEstoque extends Component {
    static displayName = GerirEstoque.name;

  constructor(props) {
      super(props);    
      this.cadastrarEstoque = this.cadastrarEstoque.bind(this);
      this.handleSave = this.handleSave.bind(this);
      this.handleCancel = this.handleCancel.bind(this);

      //Nome: '';
      //Foto: '';
      //Descricao: '';
      //Valor: '';

      var frutaid = this.props.match.params["frutaid"];      
  }

    cadastrarEstoque() {    
        alert("Cadastro realizado!");
    }

    // This will handle Cancel button click event.  
    handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/fetchFrutas");
    }

    handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // POST request for Add Frutas.  
        fetch('api/Frutas', {
            method: 'POST',
            body: data,

        }).then((response) => response.json())
            .then((responseJson) => {
                this.props.history.push("/fetchFrutas");
            })        
    }

  render() {
    return (
      <div>
        <h1>Gerir Estoque</h1>

            <p>Insira os dados para gerir o estoque de frutas.</p>

            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="EstoqueId" />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">ID Fruta</label>
                    {/*To DO - Incluir combo com os dados de frutas ja cadastrado */}
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name" required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="photo" >Quantidade atual estoque</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="photo" required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="description" >Novo valor estoque</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="description" required />
                    </div>
                </div>                
                <div className="form-group">
                    <button type="submit" className="btn btn-primary" onClick={this.cadastrarEstoque}>Salvar</button>
                    <button className="btn btn-primary" onClick={this.handleCancel}>Cancelar</button>
                </div >
            </form >
      </div>
      );

  }
}
