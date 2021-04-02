using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities.Entities
{
    /// <summary>       
    /// Defines user with specific properties.       
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Gets or sets the birth year.
        /// </summary>
        [Required]
        [PersonalData]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets collection of clients.
        /// </summary>
        public virtual ICollection<Client> Clients { get; set; }
    }
}
