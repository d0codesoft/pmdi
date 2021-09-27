using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pmdi.Data;
using pmdi.Model;
using DBID = System.Int32;

namespace pmdi
{
    [Authorize]
    //[AllowAnonymous]
    public class GetPatient : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GetPatient> _logger;

        public GetPatient(ApplicationDbContext context, ILogger<GetPatient> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: GetPatientInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: GetPatientInfo/Details/5
        public async Task<IActionResult> Details(DBID? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // GET: GetPatientInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetPatientInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsers,FirstName,LastName,MiddleName,DOB,PhotoPatient")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                //patients.Id = Guid.NewGuid();
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patients);
        }

        // GET: GetPatientInfo/Edit/5
        public async Task<IActionResult> Edit(DBID? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);
        }

        // POST: GetPatientInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DBID id, [Bind("Id,IdUsers,FirstName,LastName,MiddleName,DOB,PhotoPatient")] Patients patients)
        {
            if (id != patients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsExists(patients.Id))
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
            return View(patients);
        }

        // GET: GetPatientInfo/Delete/5
        public async Task<IActionResult> Delete(DBID? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // POST: GetPatientInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var patients = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientsExists(DBID id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
