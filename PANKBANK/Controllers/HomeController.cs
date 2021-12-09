using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PANKBANK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PANKBANK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDBContext db;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            db = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GetAppli dop)
        {
            db.GepApplis.Add(dop);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Applications()
        {
            return View(await db.GepApplis.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                GetAppli dop = await db.GepApplis.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                    return View(dop);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Applications(int? id)
        {
            if (id != null)
            {
                GetAppli dop = await db.GepApplis.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                {
                    db.GepApplis.Remove(dop);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Applications");
                }
            }
            return NotFound();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
