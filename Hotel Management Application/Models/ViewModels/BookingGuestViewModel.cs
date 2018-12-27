using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models.ViewModels
{
    public class BookingGuestViewModel
    {
        public Booking Booking { get; set; }
        public BookingGuest Guest { get; set; }
    }
}
