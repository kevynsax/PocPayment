import React, { Component } from 'react';
import axios from "axios";
import './App.scss';

class App extends Component {
  state = {
    value: "3.50",
    emailPagSeguro: "blacknutstribe@gmail.com",
    tokenPagSeguro: "CCFFC0C4B75449D3B6C5C5F4E48F3483",
    hasAlert: false,
    hasError: false
  }

  handleClick = () => {
    const pagSeguro = window.PagSeguroDirectPayment;

    const value = parseFloat(this.state.value, 10);
    const currency = "BRL";
    
    //not working yet
    const applePay = {
      supportedMethods: "https://apple.com/apple-pay",
      data: {
          version: 3,
          merchantIdentifier: "merchant.com.weddings.map",
          merchantCapabilities: ["supports3DS", "supportsCredit", "supportsDebit"],
          supportedNetworks: ["amex", "discover", "masterCard", "visa"],
          countryCode: "BR",
      },
    }
    const basic = { supportedMethods: 'basic-card', data: { supporteNetworks: ['mastercard', 'visa', 'amex'] } };
    const methodData = [basic, applePay ];
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

    const limparAlerta = () => setTimeout(() => this.setState({hasAlert: false}), 6000);
    const occursError = (err, callback = () => {}) => {
      this.setState({ hasAlert: true, hasError: true}, limparAlerta);
      console.log(err);
      callback();
    }
    request.show().then(async response => {
      const { emailPagSeguro, tokenPagSeguro } = this.state;
      const { details, payerEmail, payerName, payerPhone } = response;
      const { cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear, billingAddress } = details;
      const { addressLine, city, country, dependentLocality, organization, postalCode, recipient, region } = billingAddress;


      var sessionPagSeguro = (await axios.get(`/api/Payments/?email=${emailPagSeguro}&token=${tokenPagSeguro}`)).data;
      pagSeguro.setSessionId(sessionPagSeguro);

      console.log(details);

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
            }).catch(err => occursError(err, () => response.complete("fail")));
          }
        })
      })
    }).catch(err => occursError(err))
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
