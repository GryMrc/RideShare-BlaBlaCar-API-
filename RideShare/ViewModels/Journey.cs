using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.ViewModels
{
    public class Journey
    {
    [Required]
    public string Departure { get; set; }
    [Required]
    public string Destination { get; set; }
    [Required]
    public DateTime? JourneyDate { get; set; }
    [Required]
    public int? SeatNumber { get; set; } // integer ve dateTime gibi veri tipleri defaultta veriye sahip oldugu icin ancak bu sekil required kontrolu edilebilir.
    public string Comment { get; set; }
    }
}
