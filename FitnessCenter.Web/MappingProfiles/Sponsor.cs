using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class SponsorProfile : Profile
    {
        public SponsorProfile()
        {
            CreateMap<Sponsor, SponsorsManageViewModel>();
            CreateMap<SponsorsManageViewModel, Sponsor>().ForMember(x => x.Photo, obj => obj.Ignore());
        }
    }
}
