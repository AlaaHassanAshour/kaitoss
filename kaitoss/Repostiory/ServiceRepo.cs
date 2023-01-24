using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Repostiory
{
    public class ServiceRepo: IServicesRepo
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<kaitoss.Data.Models.Services> Add(kaitoss.Data.Models.Services entity)
        {
            await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<List<kaitoss.Data.Models.Services>> GetAll()
        {
            var entityes = await _context.Services.ToListAsync();

            return entityes;
        }

        public async Task<kaitoss.Data.Models.Services> GetById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<kaitoss.Data.Models.Services> Update(int id, kaitoss.Data.Models.Services entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = _context.Services.FirstOrDefault(b => b.Id == id);
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
