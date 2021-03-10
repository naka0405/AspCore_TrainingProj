using Banks.Entities.Entities;
using Banks.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities
{
    public class Account:BaseEntity
    {
        [Required]
        public string Number { get; set ; }
        [Required]
        public Currencies Currency { get; set; }
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
