using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pmdi.Areas.Identity.Data;

namespace pmdi.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebAppUser, WebAppRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TypeUser> TypeUsers { get; set; }

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
