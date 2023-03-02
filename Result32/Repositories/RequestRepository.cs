using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Result32.Models.Db;

namespace Result32.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            //добавление лога
            var entry = _context.Entry(request);

            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequest()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}