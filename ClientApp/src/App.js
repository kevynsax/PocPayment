import React, { Component } from 'react';
import axios from "axios";
import './App.scss';

class App extends Component {
  state = {
    value: "3.50",
    emailPagSeguro: "blacknutstribe@gmail.com",
    tokenPagSeguro: "CCFFC0C4B75449D3B6C5C5F4E48F3483",
    hasAlert: false,
    hasError: false,
    obj: ""
  }
  merchantId = "merchant.com.weddings.map";

  limparAlerta = () => setTimeout(() => this.setState({ hasAlert: false }), 6000);
  occursError = (err, callback = () => { }) => {
    this.setState({ hasAlert: true, hasError: true }, this.limparAlerta);
    console.log(err);
    callback();
  }

  makePayment = async (data, completeSuccess, completeError ) => {
    const value = parseFloat(this.state.value, 10);
    const { emailPagSeguro, tokenPagSeguro } = this.state;

    const urlPayment = "/api/Payments/";
    const pagSeguro = window.PagSeguroDirectPayment;
    const { payerEmail, payerName, payerPhone, cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear, billingAddress} = data;
    const { addressLine, city, country, dependentLocality, organization, postalCode, recipient, region } = billingAddress;

    var sessionPagSeguro = (await axios.get(`${urlPayment}?email=${emailPagSeguro}&token=${tokenPagSeguro}`)).data;
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
          axios.post(urlPayment, {
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
            this.setState({ hasAlert: true, hasError: false }, this.limparAlerta);
            completeSuccess();
            ;
          }).catch(err => this.occursError(err, completeError));
        }
      })
    })
  }

  requestPaymentApi = async () => {

    const value = parseFloat(this.state.value, 10);
    const currency = "BRL";
    const supportedNetworks = ['mastercard', 'visa', 'amex'];

    //not working yet
    const applePay = {
      supportedMethods: "https://apple.com/apple-pay",
      data: {
        version: 3,
        merchantIdentifier: this.merchantId,
        merchantCapabilities: ["supportsCredit"],
        supportedNetworks,
        countryCode: "BR",
      },
    }
    const basic = { supportedMethods: 'basic-card', data: { supportedNetworks } };
    const methodData = [basic, applePay];
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

    request.onmerchantvalidation = event =>
      axios.post("/api/MerchantValidation", {
        requestUrl: event.validationURL,
        merchantId: this.merchantId,
        displayName: "Weddings Map"
      }).then(response => {
        event.complete(response.data);
        this.setState({ obj: JSON.stringify(response.data) });
      });
    

    const response = await request.show();
    response.complete("success");

    request.show().then(async response => {
      const { details, payerEmail, payerName, payerPhone } = response;
      const { cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear, billingAddress } = details;

      console.log(response, details);

      const data = { payerEmail, payerName, payerPhone, cardNumber, cardSecurityCode, cardholderName, expiryMonth, expiryYear, billingAddress }
      this.makePayment(data, () => response.complete("success"), () => response.complete("fail"));

    }).catch(err => this.occursError(err))
  }

  handleClick = async () => {
    // if(window.ApplePaySession)
    //   alert("tem apple pay");
    await this.requestPaymentApi();
  }

  render() {
    const { emailPagSeguro, tokenPagSeguro } = this.state;
    const { value, hasError, hasAlert, obj } = this.state;

    const msg = hasError ? "Erro na hora de realizar o pagamento" : "Pagamento feito com sucesso";
    const clas = `alert ${hasError ? "error" : "success"}`;
    return (
      <div className="app">
        <div className={alert}>{obj}</div>
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
