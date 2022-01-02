using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class SupplementProfile : Profile
    {
        public SupplementProfile()
        {
            CreateMap<Supplement, SupplementsManageViewModel>();
            CreateMap<SupplementsManageViewModel, Supplement>().ForMember(x=>x.Photo, obj=>obj.Ignore());
        }
    }
}
