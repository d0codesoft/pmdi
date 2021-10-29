using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pmdi.Data;
using pmdi.Model;
using pmdi.Areas.Identity.Data;
using DBID = System.Int32;

namespace pmdi.Pages
{
    public class GetInfoPatientModel : PageModel
    {
        private readonly pmdi.Data.ApplicationDbContext _context;
        private readonly UserManager<WebAppUser> _manager;
        private readonly IAuthorizationService _authorizationService;

        public GetInfoPatientModel(pmdi.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<WebAppUser> userManager)
        {
            _context = context;
            _manager = userManager;
            _authorizationService = authorizationService;
        }

        public string Id { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
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

            dataPage = new DataPage();

            dataPage.Patient = _context.Patients.FirstOrDefault(p => p.Id == Token.PatientId);
            dataPage.Medical = _context.MedicalTreatment
                    .Where(m => m.PatientId == Token.PatientId).ToList();
            dataPage.VitalSigns = _context.VitalSignsPatients
                    .Where(m => m.PatientId == Token.PatientId)
                    .OrderByDescending(t => t.MeasurementDate).Take(5)
                    .ToList();
            dataPage.Medicines = _context.PatientMedicine
                    .Include(p => p.Drugs)
                    .Include(p => p.UnitDosage)
                    .Where(t => (t.PatientId == Token.PatientId && (t.EndReception > DateTime.UtcNow || t.EndReception == null)))
                    .OrderBy(t => t.Id)
                    .ToList();
            dataPage.Culture = CultureInfo.CreateSpecificCulture("en-US");

            dataPage.UserPatient = _context.Users.FirstOrDefault(p => p.Id == dataPage.Patient.UserId);

            if (string.IsNullOrEmpty(dataPage.Patient.PhoneNumber))
            {
                dataPage.UserPhone = dataPage.UserPatient.PhoneNumber;
            } else
            {
                dataPage.UserPhone = dataPage.Patient.PhoneNumber;
            }
            if (string.IsNullOrEmpty(dataPage.Patient.EmailAddress))
            {
                dataPage.UserPhone = dataPage.UserPatient.Email;
            }
            else
            {
                dataPage.UserPhone = dataPage.Patient.EmailAddress;
            }

            return Page();
        }

        public record DataPage
        {
            public Patients Patient { get; set; }
            public ICollection<MedicalTreatment> Medical { get; set; }
            public ICollection<VitalSignsPatients> VitalSigns { get; set; }
            public ICollection<PatientMedicine> Medicines { get; set; }
            public CultureInfo Culture { get; set; }
            public WebAppUser UserPatient { get; set; } 
            public string UserEmail { get; set; }
            public string UserPhone { get; set; }
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
