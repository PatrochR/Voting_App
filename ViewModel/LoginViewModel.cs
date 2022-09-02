using System.ComponentModel.DataAnnotations;
namespace Voting_App.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "نام کاربری", AutoGenerateFilter=false)]  

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور", AutoGenerateFilter=false)]  
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}