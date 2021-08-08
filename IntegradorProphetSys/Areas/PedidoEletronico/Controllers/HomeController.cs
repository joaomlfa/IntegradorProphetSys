using IntegradorProphetSys.Areas.PedidoEletronico.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegradorProphetSys.ApiChamadas.SuasVendas;
using IntegradorProphetSys.Areas.PedidoEletronico.Data.ApiChamadas;
using Microsoft.AspNetCore.Http;
using IntegradorProphetSys.Enum;
using IntegradorProphetSys.Areas.PedidoEletronico.Data.Session;
using IntegradorProphetSys.Bibliotecas.Attributes;
using IntegradorProphetSys.Bibliotecas.Sessao;
using IntegradorProphetSys.Models.Usuario;
using IntegradorProphetSys.DataBase.Repositories;
using IntegradorProphetSys.DataBase.Interfaces;

namespace IntegradorProphetSys.Areas.PedidoEletronico.Controllers
{
    [Area("PedidoEletronico")]
    public class HomeController : Controller
    {
        private readonly SessionPedidoEletronico _sessionPedidoEletronico;
        private readonly SessionUsuario _sessionUsuario;
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(SessionPedidoEletronico sessionPedidoEletronico, SessionUsuario sessionUsuario, IUsuarioRepository usuarioRepository)
        {
            _sessionPedidoEletronico = sessionPedidoEletronico;
            _sessionUsuario = sessionUsuario;
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        [AutorizacaoRequerida]
        public IActionResult Index()
        {
            UsuarioModel usuario = _sessionUsuario.GetUsuario();
            if(usuario.usr_token_pedido_eletronico == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Dashboard", new { area = "PedidoEletronico" });
            }
            
        }
        [HttpPost]
        public IActionResult Index([FromForm] PedidoEletronicoTokenModel tokenModel )
        {
            if (ModelState.IsValid)
            {
                var testePedidoEletronico = Task.Run(async () => await TestePedidoEletronico.TesteConexaoPedidoEletronicoAsync(tokenModel.TokenPedidoEletronico)).Result;               
                if(testePedidoEletronico == 200)
                {
                    #region Atualizar Token Pedido Eletronico no banco de dados
                    UsuarioModel usuario = _sessionUsuario.GetUsuario();
                    usuario.usr_token_pedido_eletronico = tokenModel.TokenPedidoEletronico;
                    _usuarioRepository.Atualizar(usuario);
                    #endregion

                    #region Adicionar token SuasVendas A Session e Cadastro da mesma
                    tokenModel.TokenSuasVendas = usuario.usr_token_suasvendas;
                    _sessionPedidoEletronico.CadastrarTokens(tokenModel);
                    #endregion
                    
                    return RedirectToAction("Index","Dashboard");
                }
                else
                {
                     if(testePedidoEletronico == 401)
                    {
                        TempData["Erro"] = "Token Pedido Eletrônico inválido, favor verifique";
                        return View();
                    }
                    else
                    {

                        TempData["Erro"] = "Serviço Pedido Eletrônico fora do Ar, aguarde alguns minutos e tente novamente. Cod SuasVendas: Cod Pedido eletrônico: " + testePedidoEletronico.ToString() ;
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
