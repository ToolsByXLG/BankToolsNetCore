using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Model.Cmb;

namespace Web.Controllers
{
    public class tusersController : Controller
    {
        private readonly ToolDbContext _context;

        public tusersController(ToolDbContext context)
        {
            _context = context;
        }

        // GET: tusers
        public async Task<IActionResult> Index()
        {
            return View(await _context.tuser.ToListAsync());
        }

        // GET: tusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuser = await _context.tuser
                .FirstOrDefaultAsync(m => m.id == id);
            if (tuser == null)
            {
                return NotFound();
            }

            return View(tuser);
        }

        // GET: tusers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,username,pwd,phone")] tuser tuser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tuser);
        }

        // GET: tusers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuser = await _context.tuser.FindAsync(id);
            if (tuser == null)
            {
                return NotFound();
            }
            return View(tuser);
        }

        // POST: tusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,username,pwd,phone")] tuser tuser)
        {
            if (id != tuser.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tuserExists(tuser.id))
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
            return View(tuser);
        }

        // GET: tusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tuser = await _context.tuser
                .FirstOrDefaultAsync(m => m.id == id);
            if (tuser == null)
            {
                return NotFound();
            }

            return View(tuser);
        }

        // POST: tusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tuser = await _context.tuser.FindAsync(id);
            _context.tuser.Remove(tuser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tuserExists(int id)
        {
            return _context.tuser.Any(e => e.id == id);
        }
    }
}
