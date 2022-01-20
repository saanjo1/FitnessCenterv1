using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class GoalTypeProfile : Profile
    {
        public GoalTypeProfile()
        {
            CreateMap<GoalType, GoalTypesManageViewModel>().ReverseMap();
        }
    }
}
