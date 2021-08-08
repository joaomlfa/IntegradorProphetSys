using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Bibliotecas.PasswordEncrypt
{
    public static class PasswordHashLibrary
    {
        public static byte[] GerarSenhaHashArgon2(string senha, byte[] salt)
        {
            var argon2 = new Argon2d(Encoding.UTF8.GetBytes(senha));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 16;
            argon2.Iterations = 40;
            argon2.MemorySize = 8192;
            return argon2.GetBytes(128);
         }

        public static bool VerificarHashSenha(string senhaDigitada, byte[] hashSenhaBanco, byte[] salt)
        {
            var hashNovo = GerarSenhaHashArgon2(senhaDigitada, salt);
            return hashSenhaBanco.SequenceEqual(hashNovo);
        }

        public static byte[] GerarSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
    }
}
