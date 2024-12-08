using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VetClinic.Models;

namespace VetClinic.Controllers
{
    public class DueñoController : Controller
    {
        private readonly VetContext _context;

        public DueñoController(VetContext context)
        {
            _context = context;
        }

        // GET: Dueño
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dueños.ToListAsync());
        }

        // GET: Dueño/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueños
                .FirstOrDefaultAsync(m => m.IdDueño == id);
            if (dueño == null)
            {
                return NotFound();
            }

            return View(dueño);
        }

        // GET: Dueño/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dueño/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDueño,Nombre,Apellido,Telefono,Email,Direccion,FechaRegistro")] Dueño dueño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueño);
        }

        // GET: Dueño/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueños.FindAsync(id);
            if (dueño == null)
            {
                return NotFound();
            }
            return View(dueño);
        }

        // POST: Dueño/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDueño,Nombre,Apellido,Telefono,Email,Direccion,FechaRegistro")] Dueño dueño)
        {
            if (id != dueño.IdDueño)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueño);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DueñoExists(dueño.IdDueño))
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
            return View(dueño);
        }

        // GET: Dueño/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueños
                .FirstOrDefaultAsync(m => m.IdDueño == id);
            if (dueño == null)
            {
                return NotFound();
            }

            return View(dueño);
        }

        // POST: Dueño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueño = await _context.Dueños.FindAsync(id);
            if (dueño != null)
            {
                _context.Dueños.Remove(dueño);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DueñoExists(int id)
        {
            return _context.Dueños.Any(e => e.IdDueño == id);
        }
    }
}
