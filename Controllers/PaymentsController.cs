using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using pocPagSeguro.Model;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace pocPagSeguro.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public PaymentsController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

        [HttpGet("")]
        public async Task<string> GetSessionId(string email, string token){
            var url = $"https://ws.pagseguro.uol.com.br/v2/sessions/?email={email}&token={token}";
            var client = _clientFactory.CreateClient();
            var response = await (await client.PostAsync(url, null)).Content.ReadAsStringAsync();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);

            return xml.LastChild.FirstChild.FirstChild.Value;
        }

        [HttpPost("")]
        public async Task<string> MakePayment([FromBody] MakePaymentModelView obj)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            var url = $"https://ws.pagseguro.uol.com.br/v2/transactions?email={obj.EmailPagSeguro}&token={obj.TokenPagSeguro}";
            var dic = new Dictionary<string, string>();
            dic.Add("paymentMode", "default");
            dic.Add("paymentMethod", "creditCard");
            dic.Add("receiverEmail", obj.EmailPagSeguro);
            dic.Add("currency", "BRL");
            dic.Add("extraAmount", "0.00");
            dic.Add("itemId1", "0001");
            dic.Add("itemDescription1", "Teste Payment");
            dic.Add("itemAmount1", obj.Value.ToString("0.00"));
            dic.Add("itemQuantity1", "1");
            dic.Add("senderName", obj.Name);
            dic.Add("senderCPF", obj.CPF);
            dic.Add("senderAreaCode", obj.AreaCode);
            dic.Add("senderPhone", obj.NumberPhone);
            dic.Add("senderEmail", obj.Email);
            dic.Add("senderHash", obj.HashCLient);
            dic.Add("shippingAddressRequired", "false");
            dic.Add("creditCardToken", obj.CardToken);
            dic.Add("installmentQuantity", "1");
            dic.Add("installmentValue", obj.Value.ToString("0.00"));
            dic.Add("noInterestInstallmentQuantity", "2");
            dic.Add("creditCardHolderName", obj.CardholderName);
            dic.Add("creditCardHolderCPF", obj.CPF);
            dic.Add("creditCardHolderBirthDate", obj.BirthDate);
            dic.Add("creditCardHolderAreaCode", obj.AreaCode);
            dic.Add("creditCardHolderPhone", obj.NumberPhone);
            dic.Add("billingAddressStreet", obj.BillingAddress.AddressStreet);
            dic.Add("billingAddressNumber", obj.BillingAddress.Number);
            dic.Add("billingAddressComplement", "");
            dic.Add("billingAddressDistrict", obj.BillingAddress.Neighbour);
            dic.Add("billingAddressPostalCode", obj.BillingAddress.PostalCode);
            dic.Add("billingAddressCity", obj.BillingAddress.City);
            dic.Add("billingAddressState", obj.BillingAddress.StateCode);
            dic.Add("billingAddressCountry", "BRA");

            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dic) };
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(body);

            return xml.LastChild.SelectNodes("code")[0].FirstChild.Value;
        }

    }
}
