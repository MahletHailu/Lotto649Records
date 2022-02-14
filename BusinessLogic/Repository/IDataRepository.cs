using BusinessLogic.Models.DataTransferObjects;
using BusinessLogic.Models.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> SearchAsync(Selection selection);
    }
}
