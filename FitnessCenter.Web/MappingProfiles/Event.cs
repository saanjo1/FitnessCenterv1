using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventsManageViewModel>();
            CreateMap<EventsManageViewModel, Event>().ForMember(x => x.Photo, obj => obj.Ignore());
        }
    }
}
