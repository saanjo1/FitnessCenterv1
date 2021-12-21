using FitnessCenter.Data;
using FitnessCenter.Data.Entities;
using FitnessCenter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public UsersController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        
        public IActionResult Index()
        {
            var users = _databaseContext.Users.Select(selector => new User
            {
                FirstName = selector.FirstName,
                LastName = selector.LastName,
                Email = selector.Email,
                Username = selector.Username,
            }).ToList();

            var userIndex = new UsersIndexViewModel();
            userIndex.Users = users;

            return View(userIndex);
        }


    }
}
