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
    public class Games_LojaController : Controller
    {
        private readonly Application_DB_Context _context;

        public Games_LojaController(Application_DB_Context context)
        {
            _context = context;
        }

        // GET: Games_Loja
        public async Task<IActionResult> Index()
        {
            List<Game_Loja> games_Loja = await _context.Games_Loja.ToListAsync();

            foreach (Game_Loja game_Loja in games_Loja)
            {
                game_Loja.Game = await _context.Games.FindAsync(game_Loja.GameId);

                game_Loja.Loja = await _context.Lojas.FindAsync(game_Loja.LojaId);
            }

            return View(games_Loja);
        }

        // GET: Games_Loja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_Loja = await _context.Games_Loja.FirstOrDefaultAsync(m => m.Id == id);

            game_Loja.Game = await _context.Games.FindAsync(game_Loja.GameId);

            game_Loja.Loja = await _context.Lojas.FindAsync(game_Loja.LojaId);

            if (game_Loja == null)
            {
                return NotFound();
            }

            return View(game_Loja);
        }

        // GET: Games_Loja/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Games = await _context.Games.ToListAsync();

            ViewBag.Lojas = await _context.Lojas.ToListAsync();

            return View();
        }

        // POST: Games_Loja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,LojaId")] Game_Loja game_Loja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game_Loja);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(game_Loja);
        }

        // GET: Games_Loja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_Loja = await _context.Games_Loja.FindAsync(id);

            if (game_Loja == null)
            {
                return NotFound();
            }

            ViewBag.Games = await _context.Games.ToListAsync();

            ViewBag.Lojas = await _context.Lojas.ToListAsync();

            return View(game_Loja);
        }

        // POST: Games_Loja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,LojaId")] Game_Loja games_Loja)
        {
            if (id != games_Loja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games_Loja);

                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!Games_LojaExists(games_Loja.Id))
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

            return View(games_Loja);
        }

        // GET: Games_Loja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game_Loja = await _context.Games_Loja.FirstOrDefaultAsync(m => m.Id == id);

            game_Loja.Game = await _context.Games.FindAsync(game_Loja.GameId);

            game_Loja.Loja = await _context.Lojas.FindAsync(game_Loja.LojaId);

            if (game_Loja == null)
            {
                return NotFound();
            }

            return View(game_Loja);
        }

        // POST: Games_Loja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game_Loja = await _context.Games_Loja.FindAsync(id);

            if (game_Loja != null)
            {
                _context.Games_Loja.Remove(game_Loja);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool Games_LojaExists(int id)
        {
            return _context.Games_Loja.Any(e => e.Id == id);
        }
    }
}
