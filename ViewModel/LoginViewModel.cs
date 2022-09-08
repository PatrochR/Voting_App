using System.ComponentModel.DataAnnotations;
namespace Voting_App.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName", AutoGenerateFilter=false)]  

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", AutoGenerateFilter=false)]  
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}