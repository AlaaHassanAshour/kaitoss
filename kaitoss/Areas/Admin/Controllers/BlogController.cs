using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using kaitoss.Services.File;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace kaitoss.Areas.Admin.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogRepo _BlogRepo;
        private readonly IFileSevices _fileSevices;
        private readonly ApplicationDbContext _context;
        public BlogController(IBlogRepo BlogRepo, IFileSevices fileSevices, ApplicationDbContext context)
        {
            _BlogRepo = BlogRepo;
            _fileSevices = fileSevices;
            _context= context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _BlogRepo.GetAll());
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _BlogRepo.GetById(id));
        }
        public async Task<IActionResult> Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users.ToList(), "Id", "Email");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Blog model,IFormFile file)
        {

            model.Logo = await _fileSevices.UploadImageAsync(file);
            await _BlogRepo.Add(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _BlogRepo.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Blog model)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _BlogRepo.Update(id, model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _BlogRepo.GetById(id));
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _BlogRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}