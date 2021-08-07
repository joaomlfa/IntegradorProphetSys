using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Data.ApiChamadas
{
    public static class TestePedidoEletronico
    {
        public static async Task<int> TesteConexaoPedidoEletronicoAsync(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://apidata.pedidoeletronico.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("xToken", token);
                HttpResponseMessage response = await client.GetAsync("Produto/ObterRegistros/1/1/2000-01-01");
                int statusCode = ((int)response.StatusCode);
                return statusCode;
            }
        }

    }
}
