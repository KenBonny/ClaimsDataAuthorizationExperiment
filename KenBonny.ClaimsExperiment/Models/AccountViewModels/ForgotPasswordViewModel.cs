using System.ComponentModel.DataAnnotations;

namespace KenBonny.ClaimsExperiment.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
