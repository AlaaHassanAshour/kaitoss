using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.AspNetCore.Mvc;

namespace kaitoss.Areas.Admin.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ISettingsRepo _SettingsRepo;

        public SettingsController(ISettingsRepo SettingsRepo)
        {
            _SettingsRepo = SettingsRepo;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _SettingsRepo.GetAll());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _SettingsRepo.GetById(id));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Settings model)
        {
          
               await _SettingsRepo.Add(model);
                return RedirectToAction("Index");
            
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _SettingsRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Settings model)
        {
            if (id == null)
            {
                return NotFound();
            }
           await _SettingsRepo.Update(id, model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _SettingsRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _SettingsRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}