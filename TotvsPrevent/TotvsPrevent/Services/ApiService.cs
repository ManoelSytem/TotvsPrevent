using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;

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
                    Message = "Por gentileza, verifique a conexão com a internet",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("http://10.120.8.16:2504");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por gentileza, verifique a conexão com rede interna TotvsBA. Servidor interno da fábrica.",
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

                var request = new Ht
                var content = new StringContent(jsonObjeto.ToString(), Encoding.UTF8, "application/Json");
                var result = await client.PostAsync(urlBase, content);

                return result;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<Response> GetList<T>(string urlBase, string preFix, string controller, string action)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{preFix}{controller}{action}";

                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);

                return new Response
                {
                    IsSuccess = true,
                    Result = list,
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
