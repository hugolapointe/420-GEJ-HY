using System;
using System.ComponentModel.DataAnnotations;

namespace BookingManager.ViewModels.Booking {
    public class BookingDetails {
        [Required]
        public string ClientName { get; set; }

        [Required]
        [Phone]
        public string ClientPhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string ClientEmailAddress { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
