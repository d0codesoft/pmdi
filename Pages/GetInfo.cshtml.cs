using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pmdi.Data;
using pmdi.Model;
using DBID = System.Int32;

namespace pmdi.Pages
{
    public class GetInfoPatientModel : PageModel
    {
        private readonly pmdi.Data.ApplicationDbContext _context;

        public GetInfoPatientModel(pmdi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string Id { get; set; }

        public IActionResult OnGet(string id)
        {

            Id = id;
            if (string.IsNullOrEmpty(Id))
            {
                return RedirectToPage("./Index");
            }

            var Token = _context.TokenSharedViewPatient.FirstOrDefault(p => p.Tsi == Id);
            if (String.IsNullOrEmpty(Token.Tsi))
            {
                return RedirectToPage("./Index");
            }

            dataPage = new()
            {
                Patient = _context.Patients.FirstOrDefault(p => p.Id == Token.PatientId),
                Medical = _context.MedicalTreatment
                    .Where(m => m.PatientId == Token.PatientId).ToList(),
                VitalSigns = _context.VitalSignsPatients
                    .Where(m => m.PatientId == Token.PatientId)
                    .OrderByDescending(t => t.MeasurementDate).Take(5)
                    .ToList(),
                Medicines = _context.PatientMedicine
                    .Include(p => p.Drugs)
                    .Include(p => p.UnitDosage)
                    .Where(t => (t.PatientId == Token.PatientId && (t.EndReception > DateTime.UtcNow || t.EndReception == null)))
                    .OrderBy(t=>t.Id)
                    .ToList(),
                Culture = CultureInfo.CreateSpecificCulture("en-US")
            };

            return Page();
        }

        public record DataPage
        {
            public Patients Patient { get; set; }
            public ICollection<MedicalTreatment> Medical { get; set; }
            public ICollection<VitalSignsPatients> VitalSigns { get; set; }
            public ICollection<PatientMedicine> Medicines { get; set; }
            public CultureInfo Culture { get; set; }
        }

        [BindProperty]
        public DataPage dataPage { get; set; }
        
        //// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Patients.Add(Patient);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
