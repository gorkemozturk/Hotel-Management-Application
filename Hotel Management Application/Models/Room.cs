using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models
{
    public class Room
    {
        public int ID { get; set; }

        public int RoomTypeID { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Status")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("RoomTypeID")]
        public virtual RoomType RoomType { get; set; }
    }
}
