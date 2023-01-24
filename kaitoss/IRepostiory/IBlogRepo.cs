using kaitoss.Data.Models;

namespace kaitoss.IRepostiory
{
    public interface IBlogRepo
    {
        Task<Blog> Add(Blog entity);
        Task<Blog> Update(int id ,Blog entity);
        Task<Blog> GetById(int id);
        Task<List<Blog>> GetAll();
        Task<bool> Delete(int id);
    }
}
