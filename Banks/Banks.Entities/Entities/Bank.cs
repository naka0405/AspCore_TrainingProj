using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities
{
    /// <summary>       
    /// Define bank entity which has collection Clients as one to many.        
    /// </summary>
    public class Bank:BaseEntity
    {
        /// <summary>
        /// Gets or sets a name of bank. 
        /// </summary>
        [Required]
        public string BankName { get; set; }
        /// <summary>
        /// Collection of clients.
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}
