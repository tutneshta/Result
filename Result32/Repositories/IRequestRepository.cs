using Result32.Models.Db;
using System.Threading.Tasks;

namespace Result32.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequest();
    }
}