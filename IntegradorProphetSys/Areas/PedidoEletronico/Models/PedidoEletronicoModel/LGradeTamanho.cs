using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorProphetSys.Areas.PedidoEletronico.Models
{
    public class LGradeTamanho
    {
        public int idGradeTamanho { get; set; }
        public string xNome { get; set; }
        public int idProduto { get; set; }
        public bool stAtivo { get; set; }
    }
}
