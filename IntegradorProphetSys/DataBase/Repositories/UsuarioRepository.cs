using IntegradorProphetSys.Bibliotecas.PasswordEncrypt;
using IntegradorProphetSys.DataBase.Contexts;
using IntegradorProphetSys.DataBase.Interfaces;
using IntegradorProphetSys.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProphetSys.DataBase.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IntegradorSuasVendasContext _integradorSuasVendasContext; 
        public UsuarioRepository(IntegradorSuasVendasContext integradorSuasVendasContext)
        {
            this._integradorSuasVendasContext = integradorSuasVendasContext;
        }
        public void Atualizar(UsuarioModel usuario)
        {
            _integradorSuasVendasContext.Update(usuario);
            _integradorSuasVendasContext.Entry(usuario).Property(o => o.usr_senha).IsModified = false;
            _integradorSuasVendasContext.Entry(usuario).Property(o => o.usr_salt).IsModified = false;
            _integradorSuasVendasContext.SaveChanges();
        }

        public UsuarioModel BuscarPorID(int id)
        {
           return  _integradorSuasVendasContext.Usuario.Where(o => o.usr_id == id).FirstOrDefault();
        }        
        public UsuarioModel BuscarPorEmail(string email)
        {
           return  _integradorSuasVendasContext.Usuario.Where(o => o.usr_email == email).FirstOrDefault();
        }

        public UsuarioModel Login (string email, string senha)
        {
            UsuarioModel usuario = BuscarPorEmail(email);
            if(usuario == null)
            {
                return null;
            }
            else
            {
                byte[] senhaBanco = usuario.usr_senha;
                bool SenhaConfere = PasswordHashLibrary.VerificarHashSenha(senha, senhaBanco, usuario.usr_salt);
                if (SenhaConfere)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }
        public void Cadastrar(UsuarioModel usuario)
        {
            usuario.usr_salt = PasswordHashLibrary.GerarSalt();
            usuario.usr_senha = PasswordHashLibrary.GerarSenhaHashArgon2(usuario.usr_senha_string, usuario.usr_salt);
            _integradorSuasVendasContext.Add(usuario);
            _integradorSuasVendasContext.SaveChanges();
        }

        public void Remover(UsuarioModel usuario)
        {
            _integradorSuasVendasContext.Remove(usuario);
            _integradorSuasVendasContext.SaveChanges();
        }

        public void AtualizarSenha(UsuarioModel usuario)
        {
            usuario.usr_salt = PasswordHashLibrary.GerarSalt();
            usuario.usr_senha = PasswordHashLibrary.GerarSenhaHashArgon2(usuario.usr_senha_string, usuario.usr_salt);
            _integradorSuasVendasContext.Update(usuario);
            _integradorSuasVendasContext.SaveChanges();

        }
    }
}
