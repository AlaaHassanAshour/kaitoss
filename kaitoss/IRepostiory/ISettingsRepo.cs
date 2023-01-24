using kaitoss.Data.Models;

namespace kaitoss.IRepostiory
{
    public interface ISettingsRepo
    {
        Task<Settings> Add(Settings entity);
        Task<Settings> Update(int id, Settings entity);
        Task<Settings> GetById(int id);
        Task<List<Settings>> GetAll();
        Task<bool> Delete(int id);
    }
}
