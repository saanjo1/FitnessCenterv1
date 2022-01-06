using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Web.ViewComponents
{
    [ViewComponent(Name ="Announcements")]
    public class AnnouncementsViewComponent : ViewComponent
    {
        private readonly DatabaseContext _databaseContext;

        public AnnouncementsViewComponent(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _databaseContext.Announcements.ToListAsync();
            return View(items);
        }
    }
}
