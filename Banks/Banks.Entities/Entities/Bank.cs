using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities
{
    public class Bank:BaseEntity
    {
        [Required]
        public string BankName { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
