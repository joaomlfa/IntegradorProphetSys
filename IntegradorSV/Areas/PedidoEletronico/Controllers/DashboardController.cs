using IntegradorSV.Areas.PedidoEletronico.Data.ApiChamadas;
using IntegradorSV.Bibliotecas.Attributes;
using IntegradorSV.Bibliotecas.Sessao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Controllers
{
    [Area("PedidoEletronico")]
    public class DashboardController : Controller
    {
        
        private readonly SessionUsuario _sessionUsuario;
        public DashboardController(SessionUsuario sessionUsuario)
        {
            _sessionUsuario = sessionUsuario;
        }
        [HttpGet]
        [AutorizacaoRequerida]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public int VerificarPedidosNovosAtualizados()
        {
            return 1;
        }

        [HttpGet]
        public string VerificarProdutosNovosAtualizados()
        {

            ProdutoChamadaPedidoEletronico produtoPedidoEletronico = new ProdutoChamadaPedidoEletronico();
            string dateTime = Newtonsoft.Json.JsonConvert.SerializeObject(DateTime.Now.ToString("u"));
            var response = Task.Run(async () => await produtoPedidoEletronico.ObterProdutosAdicionadosAtualizados(dateTime, this.HttpContext, _sessionUsuario)).Result;
            return response.ToString();
        }
    }
}
