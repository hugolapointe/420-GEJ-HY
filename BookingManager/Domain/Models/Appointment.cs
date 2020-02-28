using System;
using System.ComponentModel.DataAnnotations;

namespace BookingManager.Domain.Models {
    public class Appointment {
        public Guid Id { get; set; }

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

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
