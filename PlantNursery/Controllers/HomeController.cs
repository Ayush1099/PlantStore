using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNursery.Models;
using System.Diagnostics;

namespace PlantNursery.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlantNurseryDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PlantNurseryDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plants plant)
        {
            _logger.LogInformation("Read Method Executed");
            if (ModelState.IsValid)
            {
                plant.PlantName = plant.PlantName.ToLower().Replace(" ", "-");

                var slug = await _context.Plants.FirstOrDefaultAsync(p => p.PlantName == plant.PlantName);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists.");
                    return View(plant);
                }

                _context.Add(plant);
                await _context.SaveChangesAsync();

                return RedirectToAction("Read");
            }

            return View(plant);
        }

        public IActionResult Read()
        {
            _logger.LogInformation("Read Method Started");
            var response = _context.Plants;
            _logger.LogInformation("Read Method Ended");

            return View(response);
        }
        public async Task<IActionResult> Update(string id)
        {
            Plants product = await _context.Plants.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Plants plant)
        {
            _logger.LogInformation("Update Method Started");
            _context.Update(plant);
            await _context.SaveChangesAsync();

            ViewBag.Message = "The Plant has been updated!";

            return View(plant);
            _logger.LogInformation("Update Method Ended");
        }
        public async Task<IActionResult> Delete(string id)
        {
            _logger.LogInformation("Delete Method Started");
            var plants = await _context.Plants.FindAsync(id);

            _context.Plants.Remove(plants);
            await _context.SaveChangesAsync();

            ViewBag.Message = "The product has been deleted!";
            _logger.LogInformation("Delete Method Ended");

            return RedirectToAction("Read");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}