using FitnessCenter.Web.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.ViewModels
{
    public class ReservationsManageViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(DateTimeFrom), ResourceType = typeof(Translations))]
        public DateTime DateTimeFrom { get; set; }

        [Required]
        [Display(Name = nameof(DateTimeTo), ResourceType = typeof(Translations))]
        public DateTime DateTimeTo { get; set; }

        [Display(Name = nameof(Translations.User), ResourceType = typeof(Translations))]
        public int? UserId { get; set; }

        [Display(Name = nameof(Translations.Coach), ResourceType = typeof(Translations))]
        public int? CoachId { get; set; }

        [Required]
        [Display(Name = nameof(Translations.FitnessRoom), ResourceType = typeof(Translations))]
        public int FitnessRoomId { get; set; }
    }
}
