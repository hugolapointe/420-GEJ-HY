using System;
using System.ComponentModel.DataAnnotations;

using BookingManager.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace BookingManager.ViewModels.Booking {
    public class BookingCreation {
        [Required(ErrorMessage = "Please enter a name.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string ClientPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string ClientEmailAddress { get; set; }

        [Required(ErrorMessage = "Please select a date.")]
        [Remote("IsDateInFuture", "Validate")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "Please accept the terms and conditions.")]
        public bool TermsAccepted { get; set; }
    }
}
