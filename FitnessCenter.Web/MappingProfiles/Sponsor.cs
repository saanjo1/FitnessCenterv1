using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class SponsorProfile : Profile
    {
        public SponsorProfile()
        {
            CreateMap<Sponsor, SponsorsManageViewModel>().ReverseMap();
        }
    }
}
