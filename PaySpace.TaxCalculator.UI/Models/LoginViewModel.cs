using System.ComponentModel.DataAnnotations;

namespace PaySpace.TaxCalculator.UI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string twoFactorCode { get; set; } = string.Empty;
        public string twoFactorRecoveryCode { get; set; } = string.Empty;
        public bool isvalid { get; set; } = true;
    }
}
