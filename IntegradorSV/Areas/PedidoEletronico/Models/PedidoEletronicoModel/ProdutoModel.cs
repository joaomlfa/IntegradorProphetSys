using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Models
{
    public class ProdutoModel
    {
        public int idProduto { get; set; }
        public string cAlternativo { get; set; }
        public string xNome { get; set; }
        public string xUnidadeMedida { get; set; }
        public decimal vCompra { get; set; }
        public decimal pIcms { get; set; }
        public decimal pIpi { get; set; }
        public decimal pSt { get; set; }
        public decimal pOutras { get; set; }
        public decimal vCusto { get; set; }
        public decimal vEstoqueMax { get; set; }
        public decimal vEstoqueMin { get; set; }
        public string xAnotacao { get; set; }
        public string xFabricante { get; set; }
        public decimal pComissao { get; set; }
        public bool stVendaSemEstoque { get; set; }
        public bool stAtivo { get; set; }
        public decimal vVenda { get; set; }
        public decimal pLucro { get; set; }
        public string xMeuID { get; set; }
        public DateTime dtCadastro { get; set; }
        public decimal pIpiVenda { get; set; }
        public decimal pStVenda { get; set; }
        public string xNcm { get; set; }
        public string cEan { get; set; }
        public string xCategoria { get; set; }
        public string xRepresentada { get; set; }
        public decimal dPesoLiq { get; set; }
        public decimal dPesoBruto { get; set; }
        public decimal vMinimoVendas { get; set; }
        public bool bExibirAnotacaoNoPedido { get; set; }
        public List<LGradeCor> lGradeCor { get; set; }
        public List<LGradeTamanho> lGradeTamanho { get; set; }
    }
}
