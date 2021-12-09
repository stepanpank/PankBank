using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PANKBANK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PANKBANK.Controllers
{
    public class CreditController : Controller
    {
        private AppDBContext db;

        public CreditController(AppDBContext context)
        {
            db = context;
        }
        [Authorize]
        public async Task<IActionResult> Credit()
        {
            return View(await db.CreditTablModels.ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreditTablModel dop)
        {
            db.CreditTablModels.Add(dop);
            await db.SaveChangesAsync();
            return RedirectToAction("Credit");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                CreditTablModel dop = await db.CreditTablModels.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                    return View(dop);
            }
            return NotFound();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
               CreditTablModel dop = await db.CreditTablModels.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                    return View(dop);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Credit(int? id)
        {
            if (id != null)
            {
                CreditTablModel dop = await db.CreditTablModels.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                {
                    db.CreditTablModels.Remove(dop);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Credit");
                }
            }
            return NotFound();
        }
    }
}
