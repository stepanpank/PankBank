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
    public class DepositController : Controller
    {
        private AppDBContext db;

        public DepositController(AppDBContext context)
        {
            db = context;
        }
        [Authorize]
        public async Task<IActionResult> Deposit()
        {
            return View(await db.DepositTablModels.ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepositTablModel dop)
        {
            db.DepositTablModels.Add(dop);
            await db.SaveChangesAsync();
            return RedirectToAction("Deposit");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                DepositTablModel dop = await db.DepositTablModels.FirstOrDefaultAsync(p => p.Id == id);
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
                DepositTablModel dop = await db.DepositTablModels.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                    return View(dop);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(int? id)
        {
            if (id != null)
            {
                DepositTablModel dop = await db.DepositTablModels.FirstOrDefaultAsync(p => p.Id == id);
                if (dop != null)
                {
                    db.DepositTablModels.Remove(dop);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Deposit");
                }
            }
            return NotFound();
        }
    }
}
