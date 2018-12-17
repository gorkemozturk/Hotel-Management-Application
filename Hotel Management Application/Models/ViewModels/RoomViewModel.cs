using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models.ViewModels
{
    public class RoomViewModel
    {
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<RoomType> Types { get; set; }
        public Room Room { get; set; }
    }
}
