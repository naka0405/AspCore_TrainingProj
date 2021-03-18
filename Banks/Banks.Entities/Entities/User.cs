using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities.Entities
{
    /// <summary>       
    /// define user with specific properties       
    /// </summary>
    public class User : IdentityUser
    {
        [Required]
        [PersonalData]
        public int Year { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
