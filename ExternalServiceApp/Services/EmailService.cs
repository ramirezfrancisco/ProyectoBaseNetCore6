using DataAccess.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Json;

namespace ExternalServiceApp.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Servicio de SenEmail utilizado principalmente para enviar mensajes de excepciones o errores
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<bool> SendEmail(DataLog correo)
        {
            try
            {
                string urlEmail = _configuration["ConnectionStrings:RouteEmailService"]; 
                string listEmail = _configuration["ConnectionStrings:EmailsConfiguration"]; 
                
                var objSend = new
                {
                    To = listEmail,
                    Subject = "Error en servicio " + correo.service,
                    Body = "Se ha generado un error al consumir el servicio, Se envia lo siguiente: " + correo.description + " La excepcion indica " + correo.innerExeption
                };

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync(urlEmail, objSend);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Envio de factura solo por orden de venta como medida de reenvio
        /// <summary>
        /// Servicio para enviar factura a cliente, el cual recibe el nombre del archivo, el email a enviar el correo y el nombre del cliente
        /// Este servicio lee un template y reemplaza cierta información la cual se enviar junto con el archivo que se escribe
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="correo"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailInvoiceBack(string archive, string correo, string body, string invoiceId)
        {
            try
            {
                string urlEmail = _configuration["ConnectionStrings:RouteEmailAttach"];

                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new StringContent(correo), "To");
                        content.Add(new StringContent("Ejemplo de attachment"), "Subject");
                        content.Add(new StringContent(body), "Body");
                        if (!String.IsNullOrEmpty(archive))
                        {
                            byte[] bytesArchive = Convert.FromBase64String(archive);
                            var invoice = new ByteArrayContent(bytesArchive);
                            invoice.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = invoiceId,
                                FileName = invoiceId + ".pdf"
                            };
                            invoice.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            content.Add(invoice);
                        }

                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        var response = await client.PostAsync(urlEmail, content);

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                    }
                }
                return false;

            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
