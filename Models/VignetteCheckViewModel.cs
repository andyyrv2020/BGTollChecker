using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BGTollChecker.Models
{
    public class VignetteCheckViewModel
    {
        [Required(ErrorMessage = "Registration number is required.")]
        [StringLength(15, MinimumLength =2)]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryCode { get; set; } = "BG";
        public string? ApiResponse { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
