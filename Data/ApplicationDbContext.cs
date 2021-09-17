using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pmdi.Areas.Identity.Data;
using pmdi.Model;

namespace pmdi.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebAppUser, WebAppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TypeUser> TypeUsers { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<UnitDosage> UnitDosage { get; set; }
        public DbSet<ReferenceDrugs> ReferenceDrugs { get; set; }
        public DbSet<DrugsSynonym> DrugsSynonym { get; set; }
        public DbSet<PatientMedicine> PatientMedicine { get; set; }
        public DbSet<ReferenseTypeMeasuring> ReferenseTypeMeasuring { get; set; }
        public DbSet<ReferenseMeasuring> ReferenseMeasuring { get; set; }
        public DbSet<MeasuringSynonym> MeasuringSynonym { get; set; }
        public DbSet<ReferenseRelationshipMeasuring> ReferenseRelationshipMeasuring { get; set; }
        public DbSet<ReferenceUnitAnalyse> ReferenceUnitAnalyse { get; set; }
        public DbSet<TypeAnalysis> TypeAnalysis { get; set; }
        public DbSet<ReferenceAnalysis> ReferenceAnalysis { get; set; }
        public DbSet<ReferenceLabalatory> ReferenceLabalatory { get; set; }
        public DbSet<PatientAnalysis> PatientAnalysis { get; set; }
        public DbSet<DocumentsPatient> DocumentsPatient { get; set; }
        public DbSet<HistiryTackOCR> HistiryTackOCR { get; set; }
        public DbSet<TackOCR> TackOCR { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var typeUser = new TypeUser[] {
                new TypeUser{ idTypeUsers = 1, Name = "Patient" },
                new TypeUser{ idTypeUsers = 2, Name = "Doctor" }
            };

            builder.Entity<TypeUser>().HasData(typeUser);
        }
    }
}
