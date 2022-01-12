using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class GoalTypesManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Name), ResourceType = typeof(Translations))]
        public string Name { get; set; }

        [Required]
        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int UserId { get; set; }
    }
}
