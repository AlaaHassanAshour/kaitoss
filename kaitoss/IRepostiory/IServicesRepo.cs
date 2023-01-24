using kaitoss.Data.Models;

namespace kaitoss.IRepostiory
{
    public interface IServicesRepo
    {
        Task<kaitoss.Data.Models.Services> Add(kaitoss.Data.Models.Services entity);
        Task<kaitoss.Data.Models.Services> Update(int id, kaitoss.Data.Models.Services entity);
        Task<kaitoss.Data.Models.Services> GetById(int id);
        Task<List<kaitoss.Data.Models.Services>> GetAll();
        Task<bool> Delete(int id);
    }
}
