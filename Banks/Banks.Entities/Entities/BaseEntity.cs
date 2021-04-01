using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banks.Entities.Entities
{
    /// <summary>       
    /// Defines base entity.   
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets integer id for entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
    }
}
