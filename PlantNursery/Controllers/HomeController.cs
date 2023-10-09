using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNursery.Models;
using System.Diagnostics;

namespace PlantNursery.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlantNurseryDBContext _context;

        public HomeController(PlantNurseryDBContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Plants plant)
        {
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

        public IActionResult Read()
        {
            return View(_context.Plants);
        }
        public async Task<IActionResult> Update(string id)
        {
            return View(await _context.Plants.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Plants plant)
        {
            _context.Update(plant);
            await _context.SaveChangesAsync();

            ViewBag.Message = "The Plant has been updated!";

            return View(plant);
        }
        public async Task<IActionResult> Delete(string id)
        {
            _context.Plants.Remove(await _context.Plants.FindAsync(id));
            await _context.SaveChangesAsync();

            ViewBag.Message = "The product has been deleted!";

            return RedirectToAction("Read");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}