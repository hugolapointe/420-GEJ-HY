using Microsoft.AspNetCore.Mvc;
using MVExample.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVExample.Models {
    public class Appointment {
        [Required]
        [Display(Name = "Name")]
        public String ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date.")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "Please accept de terms.")]
        public bool TermsAccepted { get; set; }
    }
}
