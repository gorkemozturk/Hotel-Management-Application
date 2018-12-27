using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [Display(Name = "Room Type")]
        public int RoomTypeID { get; set; }

        [Required]
        [Display(Name = "Booking Name")]
        [StringLength(100)]
        public string BookingName { get; set; }

        [Required]
        [Display(Name = "Start On")]
        [DataType(DataType.Date)]
        public DateTime StartOn { get; set; }

        [Required]
        public int Duration { get; set; }

        [DataType(DataType.Currency)]
        public decimal Payment { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Remaining Amount")]
        public decimal RemainingAmount { get; set; }

        public int Capacity { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public virtual IEnumerable<BookingGuest> Guests { get; set; }

        [ForeignKey("RoomTypeID")]
        public virtual RoomType RoomType { get; set; }
    }
}
