using Enquete.Test.MVC.Data;
using Enquete.Test.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Enquete.Test.MVC.Controllers
{
    [Authorize]
    public class CriarEnqueteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriarEnqueteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<EnqueteTeste> enquetes;

            enquetes = _context.Enquetes.ToList();
            
            return View(enquetes);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquete = _context.Enquetes.FirstOrDefault(u => u.Id == id);

            if (enquete == null)
            {
                return NotFound();
            }

            enquete.Opcoes = _context.Opcoes.Where(o => o.EnqueteId == enquete.Id).Select(s => s).ToList();

            return View(enquete);
        }

        [HttpGet]
        public IActionResult Create()
        {
            EnqueteTeste enquete = new();

            enquete.Opcoes.Add(new Opcao() { Id = 1 });

            return View(enquete);
        }

        [HttpPost]
        public IActionResult Create(EnqueteTeste enquete)
        {

            for (int i = 0; i < enquete.Opcoes.Count; i++)
            {
                if (enquete.Opcoes[i].OpcaoDescricao == null || enquete.Opcoes[i].OpcaoDescricao.Length == 0)
                    enquete.Opcoes.Remove(enquete.Opcoes[i]);
            }

            _context.Add(enquete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var enquete = _context.Enquetes.Single(u => u.Id == id);

                enquete.Opcoes = _context.Opcoes.Where(o => o.EnqueteId == enquete.Id).Select(s => s).ToList();

                _context.SaveChanges();

                return View(enquete);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(EnqueteTeste enquete)
        {
            if (enquete.Id == 0)
            {
                return NotFound();
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var enquete = _context.Enquetes.FirstOrDefault(u => u.Id == id);

            if (enquete == null)
            {
                return NotFound();
            }

            enquete.Opcoes = _context.Opcoes.Where(o => o.EnqueteId == enquete.Id).Select(s => s).ToList();

            return View(enquete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int? id)
        {
            var enquete = _context.Enquetes.Find(id);

            if (enquete == null)
            {
                return NotFound();
            }

            enquete.Opcoes = _context.Opcoes.Where(o => o.EnqueteId == enquete.Id).Select(s => s).ToList();

            foreach(var opcao in enquete.Opcoes)
            {
                _context.Opcoes.Remove(opcao);
            }

            _context.Enquetes.Remove(enquete);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
