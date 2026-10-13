using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BGTollChecker.Models
{
    public class VignetteCheckViewModel
    {
        [Required(ErrorMessage = "Registration number is required.")]
        [StringLength(15, MinimumLength = 2)]
        [Display(Name = "Plate")]
        public string RegistrationNumber { get; set; } = "";

        [Required]
        [Display(Name = "Country")]
        public string CountryCode { get; set; } = "BG";

        public BGTollApiResponse? Result { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
