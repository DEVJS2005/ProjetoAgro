//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoAgroCoops.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedidoEstoque
    {
        public int idPedido { get; set; }
        public int idProduto { get; set; }
        public int idCooperativa { get; set; }
        public int quantidade { get; set; }
        public string observacaoProduto { get; set; }
    
        public virtual cooperativa cooperativa { get; set; }
        public virtual pedido pedido { get; set; }
        public virtual produto produto { get; set; }
    }
}
