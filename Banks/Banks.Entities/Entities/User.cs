using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities.Entities
{
    /// <summary>       
    /// Define user with specific properties.       
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets year of birthday.
        /// </summary>
        [Required]
        [PersonalData]
        public int Year { get; set; }
        /// <summary>
        /// Gets or sets collectionof clients, because user can has
        /// many client status in different banks.
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}
