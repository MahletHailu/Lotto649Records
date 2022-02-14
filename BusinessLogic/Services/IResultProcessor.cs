using BusinessLogic.Models.DataTransferObjects;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IResultProcessor<TDto>
    {
        Task<TDto> ProcessResult(SelectionDto selection);
    }
}
