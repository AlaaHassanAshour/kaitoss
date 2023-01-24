using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using kaitoss.Services.File;
using Microsoft.AspNetCore.Mvc;

namespace kaitoss.Areas.Admin.Controllers
{
    public class ServicesController : BaseController
    {
        private readonly IServicesRepo _ServicesRepo;
        private readonly IFileSevices _fileSevices;

        public ServicesController(IServicesRepo ServicesRepo, IFileSevices fileSevices)
        {
            _ServicesRepo = ServicesRepo;
            _fileSevices = fileSevices;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _ServicesRepo.GetAll());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _ServicesRepo.GetById(id));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(kaitoss.Data.Models.Services model, IFormFile file)
        {
            model.Logo = await _fileSevices.UploadImageAsync(file);
            await _ServicesRepo.Add(model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _ServicesRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, kaitoss.Data.Models.Services model)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _ServicesRepo.Update(id, model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _ServicesRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _ServicesRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }

}
