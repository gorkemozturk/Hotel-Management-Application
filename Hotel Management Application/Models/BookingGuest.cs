using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models
{
    public class BookingGuest
    {
        public int ID { get; set; }

        public int BookingID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string City { get; set; }

        [Required]
        [StringLength(15)]
        public string Province { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [ForeignKey("BookingID")]
        public virtual Booking Booking { get; set; }
    }
}
