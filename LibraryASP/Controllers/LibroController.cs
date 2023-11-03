using LibraryASP.Context;
using LibraryASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryASP.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly BibliotecaDbContext _dbContext;

        public LibroController(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
            => View(await _dbContext.Libros.ToListAsync()); 






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
