using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Bibliotecas.Attributes
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string referer = context.HttpContext.Request.Headers["referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Alerta!!! Requisição Não Segura." };
            }
            else
            {
                Uri uri = new Uri(referer);
                string hostReferer = uri.Host;
                string hostServidor = context.HttpContext.Request.Host.Host;

                if(hostReferer != hostServidor)
                {
                    context.Result = new ContentResult() { Content = "Alerta!!! Requisição Não Segura." };

                }

            }
        }
    }
}
