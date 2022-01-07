using AutoMapper;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;

namespace FitnessCenter.Web.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactsManageViewModel>();
            CreateMap<ContactsManageViewModel, Contact>().ForMember(x => x.Photo, obj => obj.Ignore());
        }
    }
}
