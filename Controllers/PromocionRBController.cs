using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RebecaBarrezueta_Examen1P.Data;
using RebecaBarrezueta_Examen1P.Models;

namespace RebecaBarrezueta_Examen1P.Controllers
{
    public class PromocionRBController : Controller
    {
        private readonly RebecaBarrezueta_Examen1PContext _context;

        public PromocionRBController(RebecaBarrezueta_Examen1PContext context)
        {
            _context = context;
        }

        // GET: PromocionRB
        public async Task<IActionResult> Index()
        {
            return View(await _context.PromocionRB.ToListAsync());
        }

        // GET: PromocionRB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionRB = await _context.PromocionRB
                .FirstOrDefaultAsync(m => m.PromocionID_RB == id);
            if (promocionRB == null)
            {
                return NotFound();
            }

            return View(promocionRB);
        }

        // GET: PromocionRB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromocionRB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromocionID_RB,Descripcion_RB,FechaPromo_RB,ZapatosID_RB")] PromocionRB promocionRB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocionRB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocionRB);
        }

        // GET: PromocionRB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionRB = await _context.PromocionRB.FindAsync(id);
            if (promocionRB == null)
            {
                return NotFound();
            }
            return View(promocionRB);
        }

        // POST: PromocionRB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromocionID_RB,Descripcion_RB,FechaPromo_RB,ZapatosID_RB")] PromocionRB promocionRB)
        {
            if (id != promocionRB.PromocionID_RB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocionRB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocionRBExists(promocionRB.PromocionID_RB))
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
            return View(promocionRB);
        }

        // GET: PromocionRB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocionRB = await _context.PromocionRB
                .FirstOrDefaultAsync(m => m.PromocionID_RB == id);
            if (promocionRB == null)
            {
                return NotFound();
            }

            return View(promocionRB);
        }

        // POST: PromocionRB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocionRB = await _context.PromocionRB.FindAsync(id);
            if (promocionRB != null)
            {
                _context.PromocionRB.Remove(promocionRB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocionRBExists(int id)
        {
            return _context.PromocionRB.Any(e => e.PromocionID_RB == id);
        }
    }
}
