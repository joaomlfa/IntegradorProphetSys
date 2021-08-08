using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Bibliotecas.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiFogery;
        
        public ValidateAntiForgeryTokenMiddleware(RequestDelegate requestDelegate, IAntiforgery antiforgery)
        {
            this._next = requestDelegate;
            this._antiFogery = antiforgery;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (HttpMethods.IsPost(httpContext.Request.Method))
            {
                await _antiFogery.ValidateRequestAsync(httpContext);
            }
            await _next(httpContext);
        }
    }
}
