using kaitoss.Data.Models;

namespace kaitoss.IRepostiory
{
    public interface IContacUsRepo
    {
        Task<ContactUs> Add(ContactUs entity);
        Task<ContactUs> Update(int id, ContactUs entity);
        Task<ContactUs> GetById(int id);
        Task<List<ContactUs>> GetAll();
        Task<bool> Delete(int id);
    }
}
