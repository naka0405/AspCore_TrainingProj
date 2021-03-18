using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities
{
    /// <summary>       
    /// define bank entity which has collection Clients as one to many        
    /// </summary>
    public class Bank:BaseEntity
    {
        [Required]
        public string BankName { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
