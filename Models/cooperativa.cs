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
    
    public partial class cooperativa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cooperativa()
        {
            this.entrada = new HashSet<entrada>();
            this.pedidoEstoque = new HashSet<pedidoEstoque>();
            this.valorUnitario = new HashSet<valorUnitario>();
        }
    
        public int idCooperativa { get; set; }
        public string nomeCooperativa { get; set; }
        public long telefone { get; set; }
        public string email { get; set; }
        public long cnpjCooperativo { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string regiao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<entrada> entrada { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidoEstoque> pedidoEstoque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<valorUnitario> valorUnitario { get; set; }
    }
}
