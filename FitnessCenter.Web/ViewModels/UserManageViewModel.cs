using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class UserManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Translations))]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = nameof(LastName), ResourceType = typeof(Translations))]
        public string LastName { get; set; }
        [Required]
        [Display(Name = nameof(Username), ResourceType = typeof(Translations))]
        public string Username { get; set; }

        [Required]
        [Display(Name = nameof(Email), ResourceType = typeof(Translations))]
        public string Email { get; set; }

        [Required]
        [Display(Name = nameof(Role), ResourceType = typeof(Translations))]
        public Role Role { get; set; }
        
        public double? ServicePrice { get; set; }
    }
}
