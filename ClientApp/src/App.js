import React, { Component } from 'react';
import axios from "axios";
import './App.scss';

class App extends Component {
  state = {
    value: "",
    emailPagSeguro: "",
    tokenPagSeguro: "",
    hasAlert: false,
    hasError: false
  }

  handleClick = () => {
    const pagSeguro = window.PagSeguroDirectPayment;

    const value = parseFloat(this.state.value, 10);
    const currency = "BRT";

    const methodData = [{ supportedMethods: 'basic-card', data: { supporteNetworks: ['mastercard', 'visa', 'amex'] } }];
    const details = {
      displayItems: [
        {
          label: "Value of Test",
          amount: { currency, value: value.toString() }
        },
      ],
      total: {
        label: "Total",
        amount: { currency, value: value.toString() }
      }
    };

    const options = {
      requestPayerName: true,
      requestPayerEmail: true,
      requestPayerPhone: true,
    }

    var request = new PaymentRequest(methodData, details, options);
    request.show().then(async response => {
      const { emailPagSeguro, tokenPagSeguro } = this.state;
      const { details, payerEmail, payerName, payerPhone } = response;
      const { cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear, billingAddress } = details;
      const { addressLine, city, country, dependentLocality, organization, postalCode, recipient, region } = billingAddress;

      const limparAlerta = () => setTimeout(() => this.setState({hasAlert: false}), 6000);

      var sessionPagSeguro = (await axios.get(`/api/Payments/?email=${emailPagSeguro}&token=${tokenPagSeguro}`)).data;
      pagSeguro.setSessionId(sessionPagSeguro);

      pagSeguro.getBrand({
        cardBin: cardNumber.substr(0, 6),
        success: ({ brand }) => pagSeguro.createCardToken({
          cardNumber,
          brand: brand.name,
          cvv: cardSecurityCode,
          expirationMonth: expiryMonth,
          expirationYear: expiryYear,
          success: ({ card }) => {
            axios.post(`/api/Payments`, {
              emailPagSeguro,
              tokenPagSeguro,
              email: payerEmail,
              name: payerName,
              phone: payerPhone,
              hashCLient: pagSeguro.getSenderHash(),
              cardToken: card.token,
              cardholderName,
              value,
              billingAddress: {
                address: addressLine.join(""),
                city,
                country,
                neighbour: dependentLocality,
                type: organization,
                postalCode,
                nameBilling: recipient,
                stateCode: region
              }
            }).then(a => {
              this.setState({hasAlert: true, hasError: false}, limparAlerta)
              response.complete("success");
            }).catch(err => {
              this.setState({ hasAlert: true, hasError: true}, limparAlerta);
              console.log(err);
              response.complete("fail");
            });
          }
        })
      })
    }).catch(err => {
      console.error(err);
    })
  }

  render() {
    const { emailPagSeguro, tokenPagSeguro } = this.state;
    const { value, hasError, hasAlert } = this.state;

    const msg = hasError ? "Erro na hora de realizar o pagamento" : "Pagamento feito com sucesso";
    const clas = `alert ${hasError ? "error" : "success"}`;
    return (
      <div className="app">
        {hasAlert && (
          <div className={clas}>{msg}</div>
        )}
        <h3>Pagamento</h3>
        <input type="email" placeholder="Email PagSeguro" value={emailPagSeguro} onChange={e => this.setState({ emailPagSeguro: e.target.value })} />
        <input type="text" placeholder="Token PagSeguro" value={tokenPagSeguro} onChange={e => this.setState({ tokenPagSeguro: e.target.value })} />
        <input type="number" placeholder="Valor" value={value} onChange={e => this.setState({ value: e.target.value })} />
        <button type="button" onClick={this.handleClick}>Pagar</button>
      </div>
    )
  }
}

export default App;
