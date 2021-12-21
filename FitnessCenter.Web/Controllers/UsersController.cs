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
            var optionList = new List<User>(new User
            {
                Email = 
            }).ToList();

            var userIndex = new UsersIndexViewModel();
            userIndex.Users = users;

            return View(userIndex);
        }
    }
}
