using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revisao_ASP_NET_SQL.Data;
using Revisao_ASP_NET_SQL.Models;

namespace Revisao_ASP_NET_SQL.Controllers
{
    public class ConsolesController : Controller
    {
        private readonly Application_DB_Context _context;

        public ConsolesController(Application_DB_Context context)
        {
            _context = context;
        }

        // GET: Consoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consoles.ToListAsync());
        }

        // GET: Consoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Consoles.FirstOrDefaultAsync(m => m.Id == id);

            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // GET: Consoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Models.Console console)
        {
            if (ModelState.IsValid)
            {
                _context.Add(console);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(console);
        }

        // GET: Consoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Consoles.FindAsync(id);

            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Models.Console console)
        {
            if (id != console.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(console);

                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsoleExists(console.Id))
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

            return View(console);
        }

        // GET: Consoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var console = await _context.Consoles.FirstOrDefaultAsync(m => m.Id == id);

            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var console = await _context.Consoles.FindAsync(id);

            if (console != null)
            {
                _context.Consoles.Remove(console);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ConsoleExists(int id)
        {
            return _context.Consoles.Any(e => e.Id == id);
        }
    }
}
