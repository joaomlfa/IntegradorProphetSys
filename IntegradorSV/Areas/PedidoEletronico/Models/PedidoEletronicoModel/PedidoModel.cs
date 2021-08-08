using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegradorSV.Areas.PedidoEletronico.Models.PedidoEletronicoModel
{
    public class PedidoModel
    {
        /// <summary>
        /// ID do registro.
        /// </summary>
        public int idPedidoVenda { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int idLocalEstoque { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int idPedidoDisplay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object NumeroPedidoIntegracao { get; set; }
        /// <summary>
        /// Identificador único do objeto da entidade Representante
        /// </summary>
        public int idRepresentantePedido { get; set; }
        /// <summary>
        /// Identificador único da entidade Clientes
        /// </summary>
        public int idClientes { get; set; }
        /// <summary>
        /// Identificador único da entidade Condição de pagamento
        /// </summary>
        public int idCondicaoPagamento { get; set; }
        /// <summary>
        /// Identificador único do objeto 
        /// </summary>
        public int idTransportadora { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object stIntegracaoTransportadora { get; set; }
        /// <summary>
        /// Identificador único do objeto para redespacho da entidade Transportadora
        /// </summary>
        public int idRedespacho { get; set; }
        /// <summary>
        /// Identificador único da entidade Status
        /// </summary>
        public int idStatus { get; set; }
        /// <summary>
        /// Pedido de compra do pedido de venda
        /// </summary>
        public string xPedidoCompra { get; set; }
        /// <summary>
        /// Motivo do cancelamento do pedido
        /// </summary>
        public object xMotivoCancelamento { get; set; }
        /// <summary>
        /// Informações adicionais do pedido
        /// </summary>
        public string xInfAdicional { get; set; }
        /// <summary>
        /// Informações adicionais do pedido
        /// </summary>
        public string xChaveNFe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object xCodigoRastreio { get; set; }
        /// <summary>
        /// Informações adicionais do pedido
        /// </summary>
        public string xNumNF { get; set; }
        /// <summary>
        /// Nome do representante vinculado ao cliente, com base no nome vinculamos o cadastro do vendedor a este cliente.
        /// </summary>
        public string xNomeRepresentanteCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object xMeuIDRepresentante { get; set; }
        /// <summary>
        /// Parâmetro para definir se é pedido ou orçamento. 0 - Orçamento / 1 - Pedido
        /// </summary>
        public int stLancamento { get; set; }
        /// <summary>
        /// Data de emissão do pedido
        /// </summary>
        public DateTime dEmissao { get; set; }
        /// <summary>
        /// Data de previsão do pedido
        /// </summary>
        public DateTime dtPrevisto { get; set; }
        /// <summary>
        /// Data de última alteração do pedido ( não editável )
        /// </summary>
        public DateTime dtUltimaAlteracao { get; set; }
        /// <summary>
        /// Desconto total do pedido
        /// </summary>
        public double vDescontoPed { get; set; }
        /// <summary>
        /// Frete do pedido
        /// </summary>
        public double vFretePed { get; set; }
        /// <summary>
        /// Outras despesas do pedido
        /// </summary>
        public double vOutrasPed { get; set; }
        /// <summary>
        /// Valor do seguro do pedido
        /// </summary>
        public double vSeguroPed { get; set; }
        /// <summary>
        /// Valor Total do produto
        /// </summary>
        public double vTotalProd { get; set; }
        /// <summary>
        /// Valor total do pedido
        /// </summary>
        public double vSubTotal { get; set; }
        /// <summary>
        /// Frete por conta de: R - Remetente | D - Destinatário | T - Terceiro | S - Sem Frete | 
        /// </summary>
        public string stFretePed { get; set; }
        /// <summary>
        /// Observação interna do pedido de venda
        /// </summary>
        public object xObsInterna { get; set; }
        /// <summary>
        /// ID do registro com base no banco de dados do integrador
        /// </summary>
        public object xMeuID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object xCepCliente { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object xCepEmpresa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object xCnpjEmpresa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double dSomaPesoItens { get; set; }
    }
}
