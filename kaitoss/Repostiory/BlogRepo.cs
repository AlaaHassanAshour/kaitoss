using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using kaitoss.Services.File;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Repostiory
{
    public class BlogRepo: IBlogRepo
    {

        private readonly ApplicationDbContext _context;
        private readonly IFileSevices _fileSevices;

        public BlogRepo(ApplicationDbContext context, IFileSevices fileSevices)
        {
            _context = context;
            _fileSevices = fileSevices;
        }
        public async Task<Blog> Add(Blog entity)
        {
            
            await _context.Blogs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model=_context.Blogs.FirstOrDefault(b => b.Id == id);  
            if (model == null)
            {
                return false;
            }
            _context.Remove(model);
          await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Blog>> GetAll()
        {
            var entityes = await _context.Blogs.ToListAsync();

            return entityes;
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<Blog> Update(int id, Blog entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
