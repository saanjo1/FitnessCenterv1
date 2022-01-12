using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentManageViewModel>();
            CreateMap<EquipmentManageViewModel, Equipment>().ForMember(x => x.Photo, obj => obj.Ignore());
        }
    }
}
