using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaveCafe.DAL;
using WaveCafe.Models;

namespace WaveCafe.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var coffeeTypes = _dbContext.CoffeeTypes
            .Include(x => x.Cofees)
            .ToList();
            return View(coffeeTypes);
        }



    }
}
