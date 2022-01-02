using FitnessCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public PhotosController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [ResponseCache(Duration = 900, Location = ResponseCacheLocation.Client, VaryByQueryKeys = new string[] {"id"})]
        public IActionResult Index(int id)
        {
            var photo = _databaseContext.Photo.Find(id);
            return File(photo.Data, "image/jpeg");
        }
    }
}
