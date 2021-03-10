using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public int Code { get; set; }
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public virtual Bank Bank {get;set;}
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<Account> Accounts { get; set; }      
    }
}
