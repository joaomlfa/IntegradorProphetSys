using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Areas.PedidoEletronico.Models
{
    public class PedidoEletronicoTokenModel
    {

        public string TokenSuasVendas { get; set; }
        [Required(ErrorMessage = "Insira o Token da plataforma Pedido Eletrônico")]
        public string TokenPedidoEletronico { get; set; }

        
    }
}
