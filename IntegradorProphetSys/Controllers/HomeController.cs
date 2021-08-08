using IntegradorProphetSys.ApiChamadas.SuasVendas;
using IntegradorProphetSys.Bibliotecas.Attributes;
using IntegradorProphetSys.Bibliotecas.Sessao;
using IntegradorProphetSys.DataBase.Interfaces;
using IntegradorProphetSys.Models;
using IntegradorProphetSys.Models.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioContext;
        private SessionUsuario _sessionUsuario;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepository, SessionUsuario sessionUsuario)
        {
            _logger = logger;
            _usuarioContext = usuarioRepository;
            _sessionUsuario = sessionUsuario;
        }
        [HttpGet]
        [AutorizacaoRequerida]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuarioModel = _usuarioContext.Login(loginModel.usr_email, loginModel.usr_senha_string);
                if (usuarioModel == null)
                {

                    TempData["Erro"] = "Email ou Senha incorreta, favor verifique.";
                    return View();
                }
                else
                {
                    _sessionUsuario.CadastrarUsuario(usuarioModel);
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioContext.Cadastrar(usuarioModel);
                TempData["Sucesso"] = "Usuário cadastrado com sucesso, efetue login.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _sessionUsuario.Logout();
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public bool ExisteEmail(string email)
        {
            UsuarioModel usuario = _usuarioContext.BuscarPorEmail(email);
            if(usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        [HttpGet]
        public bool VerificarToken(string token)
        {
            var testeSuasVendas = Task.Run(async () => await TesteSuasVendas.TesteConexaoSuasVendasAsync(token)).Result;
            if(testeSuasVendas == 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
