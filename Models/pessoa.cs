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
    
    public partial class pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pessoa()
        {
            this.pedido = new HashSet<pedido>();
        }
    
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public long telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string tipoPessoa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido> pedido { get; set; }
        public virtual pessoaFisica pessoaFisica { get; set; }
        public virtual pessoaJuridica pessoaJuridica { get; set; }
    }
}