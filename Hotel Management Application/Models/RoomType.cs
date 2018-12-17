using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementApplication.Models
{
    public class RoomType
    {
        public int ID { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [Range(1, 9999.99)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        public decimal Tax { get; set; }

        [Display(Name = "Status")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
    }
}
