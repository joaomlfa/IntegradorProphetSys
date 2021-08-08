using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegradorProphetSys.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using IntegradorProphetSys.Bibliotecas.Sessao;

namespace IntegradorProphetSys.Bibliotecas.Attributes
{
    public class AutorizacaoRequeridaAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           SessionUsuario _loginUsuario = (SessionUsuario) context.HttpContext.RequestServices.GetService(typeof(SessionUsuario));
            UsuarioModel usuario = _loginUsuario.GetUsuario();
            if(usuario == null)
            {
                context.Result = new RedirectResult("/Home/Login");
            }
        
        }
    }
}
