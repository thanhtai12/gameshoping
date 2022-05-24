using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameMasster.Data;
using GameMasster.Models;

namespace GameMasster.Controllers
{
    public class GamemasstersController : Controller
    {
        private readonly GameMassterContext _context;

        public GamemasstersController(GameMassterContext context)
        {
            _context = context;
        }

        // GET: Gamemassters
        public async Task<IActionResult> admin(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Gamemasster
                                            orderby b.Genre
                                            select b.Genre;
            var Game = from b in _context.Gamemasster
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                Game = Game.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(bookGenre))
            {
                Game = Game.Where(x => x.Genre == bookGenre);
            }
            var bookGenreVM = new GameGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Game = await Game.ToListAsync()
            };
            return View(bookGenreVM);
        }
        public async Task<IActionResult> Index(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Gamemasster
                                            orderby b.Genre
                                            select b.Genre;
            var Game = from b in _context.Gamemasster
                       select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                Game = Game.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(bookGenre))
            {
                Game = Game.Where(x => x.Genre == bookGenre);
            }
            var bookGenreVM = new GameGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Game = await Game.ToListAsync()
            };
            return View(bookGenreVM);
        }
        public async Task<IActionResult>menu(string bookGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Gamemasster
                                            orderby b.Genre
                                            select b.Genre;
            var Game = from b in _context.Gamemasster
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                Game = Game.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(bookGenre))
            {
                Game = Game.Where(x => x.Genre == bookGenre);
            }
            var bookGenreVM = new GameGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Game = await Game.ToListAsync()
            };
            return View(bookGenreVM);
        }

        // GET: Gamemassters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamemasster = await _context.Gamemasster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamemasster == null)
            {
                return NotFound();
            }

            return View(gamemasster);
        }
        public async Task<IActionResult> Add([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Link")] Gamemasster gamemasster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamemasster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamemasster);
        }
        // GET: Gamemassters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gamemassters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Link")] Gamemasster gamemasster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamemasster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamemasster);
        }

        // GET: Gamemassters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamemasster = await _context.Gamemasster.FindAsync(id);
            if (gamemasster == null)
            {
                return NotFound();
            }
            return View(gamemasster);
        }

        // POST: Gamemassters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Link")] Gamemasster gamemasster)
        {
            if (id != gamemasster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamemasster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamemassterExists(gamemasster.Id))
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
            return View(gamemasster);
        }

        // GET: Gamemassters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamemasster = await _context.Gamemasster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gamemasster == null)
            {
                return NotFound();
            }

            return View(gamemasster);
        }

        // POST: Gamemassters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamemasster = await _context.Gamemasster.FindAsync(id);
            _context.Gamemasster.Remove(gamemasster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamemassterExists(int id)
        {
            return _context.Gamemasster.Any(e => e.Id == id);
        }
    }
}
