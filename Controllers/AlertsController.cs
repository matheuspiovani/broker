using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using broker.Data;
using broker.Models;
using Microsoft.AspNetCore.Authorization;

namespace broker.Controllers
{
    [Authorize]
    public class AlertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alerts
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = _context.ApplicationUser.Where(u => u.UserName.Equals(User.Identity.Name)).First();
            var applicationDbContext = _context.Alert.Where(a => a.ApplicationUserId == user.Id).OrderByDescending(a => a.Id).Include(a => a.Stock);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alerts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alert == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .Include(a => a.Stock)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // GET: Alerts/Create
        public IActionResult Create()
        {
            ViewData["StockId"] = new SelectList(_context.Stock.OrderBy(s => s.Ticker), "Id", "Ticker");
            ApplicationUser user = _context.ApplicationUser.Where(u => u.UserName.Equals(User.Identity.Name)).First();
            ViewBag.ApplicationUserId = user.Id;

            return View();
        }

        // POST: Alerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StockId,ApplicationUserId,Price,Order")] Alert alert)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StockId"] = new SelectList(_context.Stock, "Id", "Currency", alert.StockId);
            ApplicationUser user = _context.ApplicationUser.Where(u => u.UserName.Equals(User.Identity.Name)).First();
            ViewBag.ApplicationUserId = user.Id;

            return View(alert);
        }

        // GET: Alerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alert == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert.FindAsync(id);
            if (alert == null)
            {
                return NotFound();
            }
            ViewData["StockId"] = new SelectList(_context.Stock.OrderBy(s => s.Ticker), "Id", "Ticker", alert.StockId);
            return View(alert);
        }

        // POST: Alerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StockId,ApplicationUserId,Price,Order,Email")] Alert alert)
        {
            if (id != alert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertExists(alert.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StockId"] = new SelectList(_context.Stock, "Id", "Currency", alert.StockId);
            return View(alert);
        }

        // GET: Alerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alert == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert
                .Include(a => a.Stock)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }

            return View(alert);
        }

        // POST: Alerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alert == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alert'  is null.");
            }
            var alert = await _context.Alert.FindAsync(id);
            if (alert != null)
            {
                _context.Alert.Remove(alert);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertExists(int id)
        {
          return (_context.Alert?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
