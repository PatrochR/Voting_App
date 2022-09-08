using System.ComponentModel.DataAnnotations;
namespace Voting_App.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "UserName", AutoGenerateFilter=false)]  
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Password", AutoGenerateFilter=false)]  
        public string Password { get; set; }
    }
}