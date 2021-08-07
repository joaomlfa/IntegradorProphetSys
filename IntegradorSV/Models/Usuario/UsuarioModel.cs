using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Models.Usuario
{
    public class UsuarioModel
    {
        [Key]
        public int usr_id { get; set; }
        [Required(ErrorMessage = "Informe o Nome Completo!")]
        public string usr_nome { get; set; }
        [Required(ErrorMessage = "Informe um Email!")]
        [DataType(DataType.EmailAddress)]
        public string usr_email { get; set; }
        public byte [] usr_senha { get; set; }
        [NotMapped]
        public string usr_senha_string { get; set; }
        public byte[] usr_salt { get; set; }
        [Required(ErrorMessage = "Informe o Telefone!")]
        public string usr_telefone { get; set; }
        public string usr_token_pedido_eletronico { get; set; }
        [Required(ErrorMessage = "Informe o Token SuasVendas!")]
        public string usr_token_suasvendas { get; set; }
        public DateTime usr_ultima_atualizacao_suasvendas { get; set; }
        public DateTime usr_ultima_atualizacao_pedidoeletronico { get; set; }

    }
}
