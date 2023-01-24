using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Repostiory
{
    public class CategoryRepo : ICategoryRepo
    {

        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Add(Category entity)
        {
            await _context.Categorys.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<bool> Delete(int id)
        {
            var model = _context.Categorys.FirstOrDefault(b => b.Id == id);
            if (model == null)
            {
                return false;
            }
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Category>> GetAll()
        {
            var entityes =await _context.Categorys.ToListAsync();

            return entityes;
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categorys.FindAsync(id);
        }

        public async Task<Category> Update(int id, Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

