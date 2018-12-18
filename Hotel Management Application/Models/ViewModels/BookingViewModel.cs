using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models.ViewModels
{
    public class BookingViewModel
    {
        public Booking Booking { get; set; }
        public IEnumerable<RoomType> Types { get; set; }
    }
}
