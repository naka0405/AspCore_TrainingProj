using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Code { get; set; }
        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public virtual Bank Bank {get;set;}
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }      
    }
}
