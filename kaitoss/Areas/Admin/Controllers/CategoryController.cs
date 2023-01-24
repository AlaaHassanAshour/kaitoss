using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.AspNetCore.Mvc;

namespace kaitoss.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task< IActionResult> Index()
        {
            
            return View(await _categoryRepo.GetAll());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            return View( await _categoryRepo.GetById(id));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (ModelState.IsValid)
            {
               await _categoryRepo.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int  id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _categoryRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category model)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _categoryRepo.Update(id, model);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _categoryRepo.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _categoryRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
