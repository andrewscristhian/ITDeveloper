using Curso.ITDeveloper.Domain.Interfaces.Repository;
using Curso.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Curso.ITDeveloper.Mvc.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteRepository _repoPaciente;

        public PacienteController(IPacienteRepository repoPaciente)
        {
            _repoPaciente = repoPaciente;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            //Listar Estado Paciente
            return View(await _repoPaciente.ListaPacientesComEstado());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();

            var paciente = await _repoPaciente.SelecionarPorId(id);

            if (paciente == null) return NotFound();

            return View(paciente);
        }

        public async Task<IActionResult> ReportPorEstadoPaciente(Guid? id)
        {
            if (id.Value == null) return NotFound();

            var pacientePorEstado = await _repoPaciente.ObterPacientesPorEstadoPaciente(id.Value);

            if (pacientePorEstado == null) return NotFound();

            return View(pacientePorEstado);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao");
            return View();
        }

        // POST: Paciente/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                // paciente.Id = Guid.NewGuid(); // Não usar
                await _repoPaciente.Inserir(paciente);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao");

            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id.Value == null) return NotFound();

            var paciente = await _repoPaciente.SelecionarPorId(id.Value);

            if (paciente == null) return NotFound();

            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao",
                paciente.EstadoPacienteId);

            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Paciente paciente)
        {
            if (id != paciente.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _repoPaciente.Atualizar(paciente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao");
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) return NotFound();

            var paciente = await _repoPaciente.ObterPacienteComEstadoPaciente(id);

            if (paciente == null) return NotFound();

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repoPaciente.ExcluirPorId(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id) => _repoPaciente.TemPaciente(id);
    }
}
