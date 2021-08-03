using IntegradorSV.Models.PedidoEletronicoModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegradorSV.ApiChamadas.SuasVendas;
using IntegradorSV.ApiChamadas.PedidoEletronico;
using Microsoft.AspNetCore.Http;

namespace IntegradorSV.Controllers
{
    public class PedidoEletronicoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] PedidoEletronicoTokenModel tokenModel )
        {
            if (ModelState.IsValid)
            {
                var testeSuasVendas = Task.Run(async () => await TesteSuasVendas.TesteConexaoSuasVendasAsync(tokenModel.TokenSuasVendas)).Result;
                var testePedidoEletronico = Task.Run(async () => await TestePedidoEletronico.TesteConexaoPedidoEletronicoAsync(tokenModel.TokenPedidoEletronico)).Result;               
                if(testeSuasVendas == 200 & testePedidoEletronico == 200)
                {
                    HttpContext.Session.SetString("SessionTokenPedidoEletronico", tokenModel.TokenPedidoEletronico);
                    HttpContext.Session.SetString("SessionTokenSuasVendas", tokenModel.TokenSuasVendas);
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                    if(testeSuasVendas == 401)
                    {
                        TempData["Erro"] = "Token SuasVendas inválido, favor verifique.";
                        return View();

                    }else if(testePedidoEletronico == 401)
                    {
                        TempData["Erro"] = "Token Pedido Eletrônico inválido, favor verifique";
                        return View();
                    }
                    else
                    {

                        TempData["Erro"] = "Serviço SuasVendas ou Pedido Eletrônico fora do Ar, aguarde alguns minutos e tente novamente. Cod SuasVendas: " + testeSuasVendas.ToString() +" Cod Pedido eletrônico: " + testePedidoEletronico.ToString() ;
                        return View();
                    }

                }
            }
            else
            {
                return View();
            }
            
        }
    }
}
