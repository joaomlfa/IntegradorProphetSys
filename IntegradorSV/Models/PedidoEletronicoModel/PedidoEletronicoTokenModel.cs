using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Models.PedidoEletronicoModel
{
    public class PedidoEletronicoTokenModel
    {
        [Required(ErrorMessage ="Insira o Token da plataforma SuasVendas")]
        public string TokenSuasVendas { get; set; }
        [Required(ErrorMessage = "Insira o Token da plataforma Pedido Eletrônico")]
        public string TokenPedidoEletronico { get; set; }

        
    }
}
