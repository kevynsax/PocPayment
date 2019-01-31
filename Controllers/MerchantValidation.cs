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
using Microsoft.Extensions.Logging;
using System.Security.Authentication;

namespace pocPagSeguro.Controllers
{
    [Route("api/[controller]")]
    public class MerchantValidationController : Controller
    {
        private readonly ILogger _logger;
        public MerchantValidationController(ILogger<MerchantValidationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("")]
        public async Task<object> Post([FromBody] MerchantSessionModelView model){
            _logger.LogInformation($"Solicitado session para a url {model.RequestUrl}, Host: {Request.Host.Host}");

            var certificate = GetMerchantCertificate();
            var extension = certificate.Extensions["1.2.840.113635.100.6.32"];
            var merchantId = Encoding.ASCII.GetString(extension.RawData).Substring(2);

            var validationData = new {
                merchantIdentifier = merchantId,
                domainName = Request.Host.Host,
                displayName = model.DisplayName
            };
            using (var httpClient = GetSecureHttpClient(certificate))
            {
                var jsonData = JsonConvert.SerializeObject(validationData);

                _logger.LogInformation($"dados para criar session {jsonData}");
                using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
                {
                    try
                    {
                        using (var response = await httpClient.PostAsync(model.RequestUrl, content))
                        {
                            response.EnsureSuccessStatusCode();

                            var merchantSessionJson = await response.Content.ReadAsStringAsync();
                            return JObject.Parse(merchantSessionJson);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("deu erro na hora de criar a sess�o");
                        throw new Exception("Apple Pay Gateway error: " + ex.Message);
                    }
                }
            }
        }

        [NonAction]
        public HttpClient GetSecureHttpClient(X509Certificate2 certificate){
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(certificate);
            var client = new HttpClient(handler, true);
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