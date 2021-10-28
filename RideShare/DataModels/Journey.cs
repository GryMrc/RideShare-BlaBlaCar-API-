using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.DataModels
{
    public class Journey
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime JourneyDate { get; set; }
        public int SeatNumber { get; set; }
        public string Comment { get; set; }
    }
}
