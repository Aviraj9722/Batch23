using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoCore.DBEntities;

namespace DemoCore.Controllers
{
    public class MaterailController : Controller
    {
        private  Mim23Context _context =new Mim23Context();

        public MaterailController()
        {
           
        }

        // GET: Materail
        public async Task<IActionResult> Index()
        {
            var mim23Context = _context.TblMaterials.Include(t => t.Gst).Include(t => t.Uom);
            return View(await mim23Context.ToListAsync());
        }

        // GET: Materail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterial = await _context.TblMaterials
                .Include(t => t.Gst)
                .Include(t => t.Uom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMaterial == null)
            {
                return NotFound();
            }

            return View(tblMaterial);
        }

        // GET: Materail/Create
        public IActionResult Create()
        {
            ViewData["Gstid"] = new SelectList(_context.TblGsts, "Id", "Id");
            ViewData["Uomid"] = new SelectList(_context.TblUoms, "Id", "Id");
            return View();
        }

        // POST: Materail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Uomid,Gstid,CreateOn")] TblMaterial tblMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Gstid"] = new SelectList(_context.TblGsts, "Id", "Id", tblMaterial.Gstid);
            ViewData["Uomid"] = new SelectList(_context.TblUoms, "Id", "Id", tblMaterial.Uomid);
            return View(tblMaterial);
        }

        // GET: Materail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterial = await _context.TblMaterials.FindAsync(id);
            if (tblMaterial == null)
            {
                return NotFound();
            }
            ViewData["Gstid"] = new SelectList(_context.TblGsts, "Id", "Id", tblMaterial.Gstid);
            ViewData["Uomid"] = new SelectList(_context.TblUoms, "Id", "Id", tblMaterial.Uomid);
            return View(tblMaterial);
        }

        // POST: Materail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Uomid,Gstid,CreateOn")] TblMaterial tblMaterial)
        {
            if (id != tblMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMaterialExists(tblMaterial.Id))
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
            ViewData["Gstid"] = new SelectList(_context.TblGsts, "Id", "Id", tblMaterial.Gstid);
            ViewData["Uomid"] = new SelectList(_context.TblUoms, "Id", "Id", tblMaterial.Uomid);
            return View(tblMaterial);
        }

        // GET: Materail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMaterial = await _context.TblMaterials
                .Include(t => t.Gst)
                .Include(t => t.Uom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblMaterial == null)
            {
                return NotFound();
            }

            return View(tblMaterial);
        }

        // POST: Materail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMaterial = await _context.TblMaterials.FindAsync(id);
            if (tblMaterial != null)
            {
                _context.TblMaterials.Remove(tblMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMaterialExists(int id)
        {
            return _context.TblMaterials.Any(e => e.Id == id);
        }
    }
}
