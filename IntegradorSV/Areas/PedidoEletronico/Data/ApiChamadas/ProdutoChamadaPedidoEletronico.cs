using IntegradorSV.Bibliotecas.Sessao;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Data.ApiChamadas
{
    public class ProdutoChamadaPedidoEletronico
    {

        private const string URL_BASE = "https://apidata.pedidoeletronico.com/api/";

        public ProdutoChamadaPedidoEletronico()
        {
            
        }

        public async Task<string> ObterProdutosAdicionadosAtualizados(string dataDe, HttpContext httpContext, SessionUsuario sessionUsuario)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(URL_BASE);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tokenPedidoEletronico = sessionUsuario.GetUsuario().usr_token_pedido_eletronico; 
                client.DefaultRequestHeaders.Add("xToken", tokenPedidoEletronico);
                HttpResponseMessage response = await client.GetAsync("Produto/ObterRegistros/1/100/" + "2021-08-04");

                if (response.IsSuccessStatusCode)
                {

                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
