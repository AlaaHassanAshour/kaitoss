using kaitoss.Data.Models;

namespace kaitoss.IRepostiory
{
    public interface ICategoryRepo
    {
        Task<Category> Add(Category entity);
        Task<Category> Update(int id, Category entity);
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<bool> Delete(int id);
    }
}
