using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.Models;
using kaitoss.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace kaitoss.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contet;

        public HomeController(ApplicationDbContext contet)
        {
            _contet = contet;
        }

        public async Task< IActionResult> Index()
        {
            IndexVM index = new IndexVM()
            {
                Blogs= await _contet.Blogs.AsNoTracking().Include(x=>x.AppUser).OrderByDescending(x=>x.Id).Take(3).ToListAsync(),
                Services=await _contet.Services.AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToListAsync(),
                Settings= await _contet.Settings.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==1),
            };
            return View(index);
        }
        public async Task<IActionResult> ContactUs(ContactUs model)
        {
            if (ModelState.IsValid)
            {
               await _contet.ContactUs.AddAsync(model);
                await _contet.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}