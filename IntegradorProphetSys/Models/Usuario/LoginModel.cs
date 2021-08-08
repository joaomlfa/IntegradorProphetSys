using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Models.Usuario
{
    public class LoginModel
    {
        public string usr_email { get; set; }
        public string usr_senha_string { get; set; }

        public LoginModel()
        {

        }
    }
}
