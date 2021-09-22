using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pmdi.Data;
using pmdi.Model;

namespace pmdi.Pages
{
    public class GetInfoPatientModel : PageModel
    {
        private readonly pmdi.Data.ApplicationDbContext _context;

        public GetInfoPatientModel(pmdi.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Guid Id { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Id = id;

            if (Id==Guid.Empty)
            {
                return RedirectToPage("./Index");
            }

            Id = id;
            var Token = _context.TokenSharedViewPatient.FirstOrDefault(p => p.Id == Id);
            if (Token.Tsi==Guid.Empty)
            {
                return RedirectToPage("./Index");
            }

            dataPage.Patient = _context.Patients.FirstOrDefault(p => p.Id==Token.PatientId);
            dataPage.Medical = _context.MedicalTreatment.Where(m => m.PatientId == Token.PatientId)
                .ToList();

            return Page();
        }

        public record DataPage
        {
            public Patients Patient { get; set; }
            public ICollection<MedicalTreatment> Medical { get; set; }
        }

        [BindProperty]
        //public Patients Patient { get; set; }
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
