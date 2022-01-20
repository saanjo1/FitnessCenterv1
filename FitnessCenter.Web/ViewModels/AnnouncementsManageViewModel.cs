using FitnessCenter.Data.Entities;
using FitnessCenter.Web.Resources;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class AnnouncementsManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Title), ResourceType = typeof(Translations))]
        public string Title { get; set; }

        [Required]
        [Display(Name = nameof(Description), ResourceType = typeof(Translations))]
        public string Description { get; set; }

        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int? UserId { get; set; }

        [Display(Name = nameof(Translations.Author), ResourceType = typeof(Translations))]
        public int? AuthorId { get; set; }
    }
}
