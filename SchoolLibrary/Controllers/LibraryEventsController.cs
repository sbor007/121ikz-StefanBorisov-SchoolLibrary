using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Data;
using SchoolLibrary.Models;

namespace SchoolLibrary.Controllers
{
    public class LibraryEventsController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryEventsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: LibraryEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.LibraryEvents.ToListAsync());
        }

        // GET: LibraryEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryEvent = await _context.LibraryEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryEvent == null)
            {
                return NotFound();
            }

            return View(libraryEvent);
        }

        // GET: LibraryEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Date,Location")] LibraryEvent libraryEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryEvent);
        }

        // GET: LibraryEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryEvent = await _context.LibraryEvents.FindAsync(id);
            if (libraryEvent == null)
            {
                return NotFound();
            }
            return View(libraryEvent);
        }

        // POST: LibraryEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Date,Location")] LibraryEvent libraryEvent)
        {
            if (id != libraryEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryEventExists(libraryEvent.Id))
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
            return View(libraryEvent);
        }

        // GET: LibraryEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryEvent = await _context.LibraryEvents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryEvent == null)
            {
                return NotFound();
            }

            return View(libraryEvent);
        }

        // POST: LibraryEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryEvent = await _context.LibraryEvents.FindAsync(id);
            if (libraryEvent != null)
            {
                _context.LibraryEvents.Remove(libraryEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryEventExists(int id)
        {
            return _context.LibraryEvents.Any(e => e.Id == id);
        }
    }
}
