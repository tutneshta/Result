using Result32.Models.Db;
using System.Threading.Tasks;

namespace Result32.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}