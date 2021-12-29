using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessCenter.Web.Services
{
    public class SelectLists
    {
        private readonly DatabaseContext _databaseContext;

        public SelectLists(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<SelectListItem> FitnessRooms()
        {
            return _databaseContext.FitnessRooms
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();
        }

        public List<SelectListItem> Sponsors()
        {
            return _databaseContext.Sponsors
                .Select(fr => new SelectListItem
                {
                    Text = fr.Name,
                    Value = fr.Id.ToString()
                }).ToList();
        }

        public List<SelectListItem> Users(Role? role)
        {
            return _databaseContext.Users
                .Where(u => role == null || u.Role == role.Value)
                .Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.Id.ToString(),
                }).ToList();
        }
    }
}
