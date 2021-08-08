using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntegradorProphetSys.ApiChamadas.SuasVendas
{
    public static class TesteSuasVendas
    {
        public static async Task<int> TesteConexaoSuasVendasAsync(string token)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://api.suasvendas.com/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("token", token);
                HttpResponseMessage response = await client.GetAsync("Usuario/1");
                int statusCode = ((int)response.StatusCode);
                return statusCode;
            }
        }
    }
}
