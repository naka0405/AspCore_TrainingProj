using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banks.Entities.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [PersonalData]
        public int Year { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
