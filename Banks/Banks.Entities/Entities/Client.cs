using Banks.Entities.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities
{
    /// <summary>       
    /// Defines client entity.        
    /// </summary>
    public class Client : BaseEntity
    {
        /// <summary>
        /// Gets or sets client first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets client last name.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets string client identification code.
        /// </summary>
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets bank id.
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets bank.
        /// </summary>
        [ForeignKey("BankId")]
        public virtual Bank Bank {get;set;}

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets novigation property user.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets collection of accounts.
        /// </summary>
        public virtual ICollection<Account> Accounts { get; set; }      
    }
}
