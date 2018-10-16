using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persons.Data;
using Persons.Models;

namespace Persons.Controllers
{
    public class PersonDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonData.ToListAsync());
        }

        // GET: PersonDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personData = await _context.PersonData
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personData == null)
            {
                return NotFound();
            }

            return View(personData);
        }

        // GET: PersonDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Sex")] PersonData personData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personData);
        }

        // GET: PersonDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personData = await _context.PersonData.SingleOrDefaultAsync(m => m.ID == id);
            if (personData == null)
            {
                return NotFound();
            }
            return View(personData);
        }

        // POST: PersonDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Age,Sex")] PersonData personData)
        {
            if (id != personData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonDataExists(personData.ID))
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
            return View(personData);
        }

        // GET: PersonDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personData = await _context.PersonData
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personData == null)
            {
                return NotFound();
            }

            return View(personData);
        }

        // POST: PersonDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personData = await _context.PersonData.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonData.Remove(personData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonDataExists(int id)
        {
            return _context.PersonData.Any(e => e.ID == id);
        }
    }
}
