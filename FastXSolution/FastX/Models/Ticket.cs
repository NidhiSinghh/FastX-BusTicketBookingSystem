﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastX.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }



        [ForeignKey("SeatId")]
        public int? SeatId { get; set; }
        public Seat? Seat { get; set; }

        public float? Price { get; set; }
        //public bool? IsConfirmed { get; set; }

        // Navigation Property
        public Booking? Booking { get; set; }
        

    }

}
