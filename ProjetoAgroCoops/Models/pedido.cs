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
    
    public partial class pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedido()
        {
            this.pedidoEstoque = new HashSet<pedidoEstoque>();
        }
    
        public int idPedido { get; set; }
        public int idPessoa { get; set; }
        public System.DateTime dataPedido { get; set; }
        public string status { get; set; }
    
        public virtual pessoa pessoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidoEstoque> pedidoEstoque { get; set; }
    }
}