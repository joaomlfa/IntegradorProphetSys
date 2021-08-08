using IntegradorProphetSys.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.DataBase.Interfaces
{
   public interface IUsuarioRepository
    {
        void Cadastrar(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario);
        void Remover(UsuarioModel usuario);
        UsuarioModel BuscarPorID(int id);
        UsuarioModel BuscarPorEmail(string email);
        UsuarioModel Login(string email, string senha);
        void AtualizarSenha(UsuarioModel usuario);

    }
}
