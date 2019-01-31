using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Net;
using pocPagSeguro.Model;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace pocPagSeguro.Controllers
{
    [Route("api/[controller]")]
    public class MerchantValidationController : Controller
    {

        [HttpPost("")]
        public async Task<object> Post([FromBody] MerchantSessionModelView model){
            var certificate = GetMerchantCertificate();
            var validationData = new {
                merchantIdentifier = model.MerchantId,
                initiativeContext = Request.Host.Host,
                initiative = "web",
                displayName = model.DisplayName
            };
            using (var httpClient = GetSecureHttpClient(certificate))
            {
                var jsonData = JsonConvert.SerializeObject(validationData);

                using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    try
                    {
                        using (var response = await httpClient.PostAsync($"https://{model.RequestUrl}/paymentSession", content))
                        {
                            response.EnsureSuccessStatusCode();

                            var merchantSessionJson = await response.Content.ReadAsStringAsync();
                            return merchantSessionJson;
                            return JObject.Parse(merchantSessionJson);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;//new Exception("Apple Pay Gateway error: " + ex.Message);
                    }
                }
            }
        }

        [NonAction]
        public HttpClient GetSecureHttpClient(X509Certificate2 certificate){
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(certificate);
            var client = new HttpClient(handler, true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            return client;
        }

        [NonAction]
        public X509Certificate2 GetMerchantCertificate(){
            var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            certStore.Open(OpenFlags.ReadOnly);
            var certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, "768FB33EF0724FE94A2801E60AEF345FA1B10301", false);

            if(certCollection.Count == 0)
                throw new Exception("Certified Not Found");
            
            var cert = certCollection[0];

            certStore.Close();

            return cert;
        }
    }
}