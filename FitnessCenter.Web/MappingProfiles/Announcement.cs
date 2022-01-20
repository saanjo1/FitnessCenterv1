using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementsManageViewModel>().ReverseMap();
        }
    }
}
