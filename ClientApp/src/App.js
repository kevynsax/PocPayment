import React, { Component } from 'react';
import axios from "axios";
import './App.scss';

class App extends Component {
  state = {
    value: "13.35",
    sessionPagSeguro: "86f11a8886704c078edc8583b26bdbd6"
  }

  handleClick = () => {
    const pagSeguro = window.PagSeguroDirectPayment;

    const value = parseFloat(this.state.value, 10).toString();
    const currency = "BRT";
    
    const methodData = [{ supportedMethods: 'basic-card', data: { supporteNetworks: ['mastercard', 'visa', 'amex'] } }];
    const details = {
      displayItems: [
        { 
          label: "Value of Test",
          amount: { currency, value }
        },          
      ],
      total: {
        label: "Total",
        amount: { currency, value }
      }
    };

    const options = {
      requestPayerName: true,
      requestPayerEmail: true,
      requestPayerPhone: true,
    }

    var request = new PaymentRequest(methodData, details, options);
    request.show().then(response => {
      const { details, payerEmail, payerName, payerPhone } = response;
      const { cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear } = details;
      const { sessionPagSeguro } = this.state;
      

      pagSeguro.setSessionId(sessionPagSeguro);

      pagSeguro.getBrand({
        cardBin: cardNumber.substr(0,6),
        success: ({brand}) => pagSeguro.createCardToken({
          cardNumber,
          brand: brand.name,
          cvv: cardSecurityCode,
          expirationMonth: expiryMonth,
          expirationYear: expiryYear,
          success: ({card}) => {
            console.log(card);
            response.complete("success");
          }
        })
      })
    }).catch(err => {
      console.error(err);
    })
  }

  render() {
    const { value, sessionPagSeguro} = this.state;
    return (
      <div className="app">
        <input type="email" placeholder="Sessão PagSeguro" value={sessionPagSeguro} onChange={e => this.setState({sessionPagSeguro: e.target.value})} />
        <input type="number" placeholder="Valor" value={value} onChange={e => this.setState({value: e.target.value})}/>
        <button type="button" onClick={this.handleClick}>Pagar</button>
      </div>
    )
  }
}

export default App;
