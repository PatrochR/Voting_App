using System.ComponentModel.DataAnnotations;
using Voting_App.Models;

namespace Voting_App.ViewModel
{
    public class PlanDetailsViewModel
    {
        public int PlanId {get; set;}

        [Display(Name = "Name")]
        [Required]
        public string PlanName { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string PlanDescription { get; set; }
        [Display(Name = "Image")]
        public string PlanImageUrl { get; set; }
        public List<Vote> Votes { get; set; }

    }
}