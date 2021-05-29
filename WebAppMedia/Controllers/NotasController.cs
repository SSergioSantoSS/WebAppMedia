using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMedia.Data;
using WebAppMedia.Models;


namespace WebAppMedia.Controllers
{
    public class NotasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Notas.Include(n => n.Aluno).Include(n => n.Turma);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> TopFive()
        {
            var applicationDbContext = _context.Notas.Include(n => n.Aluno).Include(n => n.Turma).OrderByDescending(n => n.Media).Take(5);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Curso");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nota01,Nota02,Nota03,Pf,Media,TurmaId,AlunoId,Id")] Nota nota)
          
        {
            if (ModelState.IsValid)
            {
                nota.Id = Guid.NewGuid();

                nota.Media = Convert.ToDecimal((nota.Nota01 + (nota.Nota02 * 1.2) + (nota.Nota03 * 1.4)) / 3.6);
                nota.Pf = 0;
                nota.Premio = 0;
                

                if (nota.Media >= 6)
                {
                    nota.SituacaoFinal = "Aprovado";
                }
                else if (nota.Media >= 4 && nota.Media < 6)
                {
                    nota.SituacaoFinal = "Prova Final";
                }
                else
                {
                    nota.SituacaoFinal = "Reprovado";
                }
                _context.Add(nota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", nota.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Curso", nota.TurmaId);
            return View(nota);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Matricula", nota.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Curso", nota.TurmaId);
            return View(nota);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nota01,Nota02,Nota03,Pf,Media,TurmaId,AlunoId,Id")] Nota nota)
        {
            if (id != nota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {


                    if (nota.Premio > 0)
                    {
                        nota.Media = Convert.ToDecimal(nota.Nota01 + nota.Nota02 + nota.Nota03 + nota.Pf + (nota.Premio * 2)) / 6;

                        _context.Update(nota);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                    if (nota.Pf > 0)
                    {
                        nota.Media = (nota.Media + Convert.ToDecimal(nota.Pf) / 2);

                        if (nota.Media >= 5)
                        {
                            nota.SituacaoFinal = "Aprovado";
                        }
                        else
                        {
                            nota.SituacaoFinal = "Reprovado";
                        }
                    }
                    _context.Update(nota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaExists(nota.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Matricula", nota.AlunoId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Curso", nota.TurmaId);
            return View(nota);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nota = await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            return View(nota);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nota = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaExists(Guid id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
