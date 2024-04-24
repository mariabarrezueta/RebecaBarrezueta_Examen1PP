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
    public class ZapatosRBController : Controller
    {
        private readonly RebecaBarrezueta_Examen1PContext _context;

        public ZapatosRBController(RebecaBarrezueta_Examen1PContext context)
        {
            _context = context;
        }

        // GET: ZapatosRB
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZapatosRB.ToListAsync());
        }

        // GET: ZapatosRB/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapatosRB = await _context.ZapatosRB
                .FirstOrDefaultAsync(m => m.ZapatosID_RB == id);
            if (zapatosRB == null)
            {
                return NotFound();
            }

            return View(zapatosRB);
        }

        // GET: ZapatosRB/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZapatosRB/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZapatosID_RB,Nombre_RB,EdicionEspecial_RB,Precio_RB")] ZapatosRB zapatosRB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zapatosRB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zapatosRB);
        }

        // GET: ZapatosRB/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapatosRB = await _context.ZapatosRB.FindAsync(id);
            if (zapatosRB == null)
            {
                return NotFound();
            }
            return View(zapatosRB);
        }

        // POST: ZapatosRB/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZapatosID_RB,Nombre_RB,EdicionEspecial_RB,Precio_RB")] ZapatosRB zapatosRB)
        {
            if (id != zapatosRB.ZapatosID_RB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zapatosRB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZapatosRBExists(zapatosRB.ZapatosID_RB))
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
            return View(zapatosRB);
        }

        // GET: ZapatosRB/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zapatosRB = await _context.ZapatosRB
                .FirstOrDefaultAsync(m => m.ZapatosID_RB == id);
            if (zapatosRB == null)
            {
                return NotFound();
            }

            return View(zapatosRB);
        }

        // POST: ZapatosRB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zapatosRB = await _context.ZapatosRB.FindAsync(id);
            if (zapatosRB != null)
            {
                _context.ZapatosRB.Remove(zapatosRB);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZapatosRBExists(int id)
        {
            return _context.ZapatosRB.Any(e => e.ZapatosID_RB == id);
        }
    }
}
