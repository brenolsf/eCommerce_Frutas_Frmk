import React, { Component } from 'react';
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';


export class Cadastro extends Component {
    static displayName = Cadastro.name;

  constructor(props) {
      super(props);    
      this.cadastrarFrutas = this.cadastrarFrutas.bind(this);
      this.handleSave = this.handleSave.bind(this);
      this.handleCancel = this.handleCancel.bind(this);

      //Nome: '';
      //Foto: '';
      //Descricao: '';
      //Valor: '';

      var frutaid = this.props.match.params["frutaid"];      
  }

    cadastrarFrutas() {    
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
        <h1>Cadastrar Frutas</h1>

            <p>Insira os dados para cadastrar as frutas.</p>

            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="FrutasId" />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Name">Nome</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="name" required />
                    </div>
                </div >
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="photo" >Foto (URL)</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="photo" required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="description" >Descricao</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="description" required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="stock" >Valor</label>
                    <div className="col-md-4">
                        <input className="form-control" required name="value" pattern="^\d*(\.\d{0,2})?$"  />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-primary" onClick={this.cadastrarFrutas}>Salvar</button>
                    <button className="btn btn-primary" onClick={this.handleCancel}>Cancelar</button>
                </div >
            </form >
      </div>
      );

  }
}
