using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;
using System.Net.Http.Headers;
using ModernHttpClient;

namespace TotvsPrevent.Services
{
    
    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por gentileza, verifique sua conexão com a internet.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("10.120.8.16",2504, 5000);
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por gentileza, verifique a conexão com a rede interna TOTVSBA. Servidor interno da fábrica.",
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }


        public async Task<HttpResponseMessage> GetToken(string urlBase, string user, string senha)
        {
            try
            {
                var client = new HttpClient();

                var objeto = new { username = user , password = senha  };

                var jsonObjeto = JsonConvert.SerializeObject(objeto);


                var content = new StringContent(jsonObjeto.ToString(), Encoding.UTF8, "application/Json");
                var result = await client.PostAsync(urlBase, content);

                return result;
            }
            catch (HttpRequestException e)
            {

                return null;
            }
        }
        public async Task<Response> GetList<T>(string urlBase, string preFix, string controller, string action, string acessToken)
        {
            try
            {
                var client = new HttpClient();
                var url = $"{urlBase}{preFix}{controller}{action}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
               
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.RequestMessage.ToString(),
                    };
                }

                var objetoResult = JsonConvert.DeserializeObject<T>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = objetoResult,
                };

            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }


        public async Task<Response> GetList<T>(string urlBase)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(urlBase);
                var answer = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.RequestMessage.ToString(),
                    };
                }

                var objetoResult = JsonConvert.DeserializeObject<T>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = objetoResult,
                };

            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

    }
}
