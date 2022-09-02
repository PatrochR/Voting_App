using System.ComponentModel.DataAnnotations;
namespace Voting_App.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "نام کابری", AutoGenerateFilter=false)]  
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "کلمه عبور", AutoGenerateFilter=false)]  
        public string Password { get; set; }
    }
}