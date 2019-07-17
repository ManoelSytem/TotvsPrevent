﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TotvsPrevent.Models;

namespace TotvsPrevent.Services
{
    
    public class WebApiService
    {
        public async Task<Response> GetList<T>(string urlBase, string preFix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{preFix}{controller}";

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
