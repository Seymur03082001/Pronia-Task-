using Microsoft.AspNetCore.Mvc;
using Pronia_Task_.DAL;
using Pronia_Task_.Models;

namespace Pronia_Task_.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find();
            if (slider != null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Delete));
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return BadRequest();
            Slider slider = _context.Sliders.Find();
            if (slider is null) return NotFound();
            return View(slider);
        }
        public IActionResult Update(int id, Slider slider)
        {
            if (id == null || id == 0 || id != slider.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            Slider anotherslider = _context.Sliders.FirstOrDefault(s => s.Order == slider.Order);
            if (anotherslider != null)
            {
                anotherslider.Order = _context.Sliders.Find(id).Order;
            }
            Slider exist = _context.Sliders.Find(id);
            exist.Order = slider.Order;
            exist.PrimaryTitle = slider.PrimaryTitle;
            exist.SecondaryTitle = slider.SecondaryTitle;
            exist.Description = slider.Description;
            exist.ImageUrl = slider.ImageUrl;
            //_context.Sliders.Update(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
