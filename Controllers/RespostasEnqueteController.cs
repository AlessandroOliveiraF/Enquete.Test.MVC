#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Enquete.Test.MVC.Data;
using Enquete.Test.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Enquete.Test.MVC.Controllers
{
    [Authorize]
    public class RespostasEnqueteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespostasEnqueteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SelecionaEnquete()
        {
            return View(_context.Enquetes);
        }

        public IActionResult DisplayForm()
        {
            RespostaEnquete respostaEnquete = new();

            return View(respostaEnquete);
        }

        [HttpPost]
        public IActionResult DisplayForm(RespostaEnquete respostaEnqueteDoFormulario)
        {
            return View(respostaEnqueteDoFormulario.ToString());
        }

        public IActionResult ResponderEnquete(EnqueteTeste enquete)
        {
            enquete = _context.Enquetes.Single(u => u.Id == enquete.Id);

            enquete.Opcoes = _context.Opcoes.Where(o => o.EnqueteId == enquete.Id).Select(s => s).ToList();

            RespostaEnquete respostaEnquete = new();

            respostaEnquete.Enquete = enquete;

            _context.Add(respostaEnquete);

            return RedirectToAction("Create");
        }

        // GET: RespostasEnquete
        public async Task<IActionResult> Index()
        {
            return View(await _context.RespostasEnquete.ToListAsync());
        }

        // GET: RespostasEnquete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaEnquete = await _context.RespostasEnquete
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respostaEnquete == null)
            {
                return NotFound();
            }

            return View(respostaEnquete);
        }

        // GET: RespostasEnquete/Create
        public IActionResult Create()
        {
            return View("DisplayForm");
        }

        // POST: RespostasEnquete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email")] RespostaEnquete respostaEnquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostaEnquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(respostaEnquete);
        }

        // GET: RespostasEnquete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaEnquete = await _context.RespostasEnquete.FindAsync(id);
            if (respostaEnquete == null)
            {
                return NotFound();
            }
            return View(respostaEnquete);
        }

        // POST: RespostasEnquete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email")] RespostaEnquete respostaEnquete)
        {
            if (id != respostaEnquete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respostaEnquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaEnqueteExists(respostaEnquete.Id))
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
            return View(respostaEnquete);
        }

        // GET: RespostasEnquete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaEnquete = await _context.RespostasEnquete.FirstOrDefaultAsync(m => m.Id == id);

            if (respostaEnquete == null)
            {
                return NotFound();
            }

            return View(respostaEnquete);
        }

        // POST: RespostasEnquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respostaEnquete = await _context.RespostasEnquete.FindAsync(id);
            _context.RespostasEnquete.Remove(respostaEnquete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaEnqueteExists(int id)
        {
            return _context.RespostasEnquete.Any(e => e.Id == id);
        }
    }
}
