using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laptops.Data;
using laptops.Models;
using Microsoft.AspNetCore.Authorization;

namespace laptops.Controllers
{
    public class LaptopsController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;
        private object await_context;

        // GET: Laptops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laptops.ToListAsync());
        }
        // GET: Laptops/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        //  POST: Laptops/ShowSearchResults
        [Authorize]
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Laptops.Where(j => j.LaptopName.Contains(SearchPhrase)).ToListAsync());

        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops
                .FirstOrDefaultAsync(m => m.LaptopName == id);
            if (laptops == null)
            {
                return NotFound();
            }

            return View(laptops);
        }

        // GET: Laptops/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
 
        public async Task<IActionResult> Create([Bind("LaptopName,Username,Location,Status")] Laptops laptops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptops);
        }

        // GET: Laptops/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops.FindAsync(id);
            if (laptops == null)
            {
                return NotFound();
            }
            return View(laptops);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("LaptopName,Username,Location,Status")] Laptops laptops)
        {
            if (id != laptops.LaptopName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopsExists(laptops.LaptopName))
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
            return View(laptops);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptops = await _context.Laptops
                .FirstOrDefaultAsync(m => m.LaptopName == id);
            if (laptops == null)
            {
                return NotFound();
            }

            return View(laptops);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var laptops = await _context.Laptops.FindAsync(id);
            if (laptops != null)
            {
                _context.Laptops.Remove(laptops);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopsExists(string id)
        {
            return _context.Laptops.Any(e => e.LaptopName == id);
        }
    }
}
