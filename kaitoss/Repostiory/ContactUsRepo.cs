using kaitoss.Data;
using kaitoss.Data.Models;
using kaitoss.IRepostiory;
using Microsoft.EntityFrameworkCore;

namespace kaitoss.Repostiory
{
    public class ContactUsRepo: IContacUsRepo
    {
        private readonly ApplicationDbContext _context;

        public ContactUsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ContactUs> Add(ContactUs entity)
        {
            await _context.ContactUs.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<List<ContactUs>> GetAll()
        {
            var entityes = await _context.ContactUs.ToListAsync();

            return entityes;
        }

        public async Task<ContactUs> GetById(int id)
        {
            return await _context.ContactUs.FindAsync(id);
        }

        public async Task<ContactUs> Update(int id, ContactUs entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var model = _context.ContactUs.FirstOrDefault(b => b.Id == id);
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
