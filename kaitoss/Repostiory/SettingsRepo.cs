using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Repostiory
{
    public class SettingsRepo: ISettingsRepo
    {
        private readonly ApplicationDbContext _context;

        public SettingsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Settings> Add(Settings entity)
        {
            await _context.Settings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<List<Settings>> GetAll()
        {
            var entityes = await _context.Settings.ToListAsync();

            return entityes;
        }

        public async Task<Settings> GetById(int id)
        {
            return await _context.Settings.FindAsync(id);
        }

        public async Task<Settings> Update(int id, Settings entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = _context.Settings.FirstOrDefault(b => b.Id == id);
            if (model == null)
            {
                return false;
            }
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
