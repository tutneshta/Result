using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Result32.Models.Db;
using Result32.Repositories;


namespace Result32.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequest();
            return View(logs);
        }
    }
}