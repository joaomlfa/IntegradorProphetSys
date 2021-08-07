using IntegradorSV.Areas.PedidoEletronico.Models;
using IntegradorSV.Bibliotecas.Sessao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Data.Session
{
    public class SessionPedidoEletronico
    {
        private const string KEY = "PedidoEletronico";
        private Bibliotecas.Sessao.Session _session;

        public SessionPedidoEletronico(Bibliotecas.Sessao.Session session)
        {
            this._session = session;
        }

        public void CadastrarTokens(PedidoEletronicoTokenModel tokens)
        {
            string chavesString = JsonConvert.SerializeObject(tokens);
            _session.Cadastrar(KEY, chavesString);
        }

        public PedidoEletronicoTokenModel GetTokens()
        {
            string chavesString = _session.Consultar(KEY);
            if (_session.Existe(KEY))
            {
                return JsonConvert.DeserializeObject<PedidoEletronicoTokenModel>(chavesString);
            }
            return null;
            
        }
    }
}
