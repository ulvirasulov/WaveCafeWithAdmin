using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaveCafe.DAL;
using WaveCafe.Models;

namespace WaveCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        AppDbContext _dbcontext;

        public CategoryController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dbcontext.CoffeeTypes.Include(c=>c.Cofees).ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoffeeType coffeeType)
        {
            _dbcontext.CoffeeTypes.Add(coffeeType);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id==null) return NotFound();
            var category = _dbcontext.CoffeeTypes.FirstOrDefault(c=>c.Id==id);
            if(category==null) return NotFound();
            _dbcontext.CoffeeTypes.Remove(category);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if(id==null) return NotFound();
            var category = _dbcontext.CoffeeTypes.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(CoffeeType newCoffeeType)
        {
            if (!ModelState.IsValid)
            {
                return View(newCoffeeType);
            }
            var oldCategory = _dbcontext.CoffeeTypes.FirstOrDefault(c => c.Id == newCoffeeType.Id);
            if (oldCategory == null) return NotFound();

            oldCategory.Name = newCoffeeType.Name;
            _dbcontext.SaveChanges();
            return RedirectToPage("Index");
        }

    }
}
