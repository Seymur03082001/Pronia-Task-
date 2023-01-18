using Microsoft.AspNetCore.Mvc;
using Pronia_Task_.DAL;

namespace Pronia_Task_.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
