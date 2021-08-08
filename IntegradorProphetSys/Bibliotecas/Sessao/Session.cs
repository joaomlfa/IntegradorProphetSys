using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Bibliotecas.Sessao
{
    public class Session
    {
        private IHttpContextAccessor _context;

        public Session(IHttpContextAccessor httpContext)
        {
            this._context = httpContext;
        }
        public void Cadastrar(string key, string value)
        {
            _context.HttpContext.Session.SetString(key, value);
        }
        public void Alterar(string key, string value)
        {
            if (Existe(key))
            {
                this.Remover(key);
            }
            this.Cadastrar(key, value);
        }
        public string Consultar(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }
        public void Remover(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }
        public bool Existe(string key)
        {
            if(_context.HttpContext.Session.GetString(key) == null)
            {
                return false;
            }

            return true;
        }
        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
