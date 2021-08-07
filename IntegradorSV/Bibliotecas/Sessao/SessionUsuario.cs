using IntegradorSV.Models.Usuario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Bibliotecas.Sessao
{
    public class SessionUsuario
    {
        private const string KEY = "Usuario";
        private Bibliotecas.Sessao.Session _session;

        public SessionUsuario(Session session)
        {
            _session = session;
        }

        public void CadastrarUsuario(UsuarioModel usuario)
        {
            usuario.usr_senha = null;
            usuario.usr_salt = null;
            string chavesString = JsonConvert.SerializeObject(usuario);
            _session.Cadastrar(KEY, chavesString);
        }

        public UsuarioModel GetUsuario()
        {
            string chavesString = _session.Consultar(KEY);
            if (_session.Existe(KEY))
            {
                return JsonConvert.DeserializeObject<UsuarioModel>(chavesString);
            }
            return null;
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }
    }
}
