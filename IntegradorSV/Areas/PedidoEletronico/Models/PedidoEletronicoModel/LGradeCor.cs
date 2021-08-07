using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Models
{
    public class LGradeCor
    {
        public int idGradeCor { get; set; }
        public string xNome { get; set; }
        public string xCor { get; set; }
        public int idProduto { get; set; }
        public bool stAtivo { get; set; }
    }

}
