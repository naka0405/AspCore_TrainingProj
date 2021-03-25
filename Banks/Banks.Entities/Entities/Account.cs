using Banks.Entities.Entities;
using Banks.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities
{
    /// <summary>       
    /// Define account entity which has navigation property Client as one.   
    /// </summary>
    public class Account:BaseEntity
    {
        /// <summary>
        /// Gets or sets account as string.
        /// </summary>
        [Required]
        public string Number { get; set ; }

        /// <summary>
        /// Gets or sets currency as enum.
        /// </summary>
        [Required]
        public Currencies Currency { get; set; }

        /// <summary>
        /// Gets or sets client id. 
        /// </summary>
        [Required]
        public int ClientId { get; set; }

        /// <summary>
        /// Navigation to client.
        /// </summary>
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
