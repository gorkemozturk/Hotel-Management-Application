using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
