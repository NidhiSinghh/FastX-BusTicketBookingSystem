﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastX.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        //paymnet status
        public float? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }=DateTime.Now;

        // Navigation Property
        public Booking? Booking { get; set; }
    }
}
