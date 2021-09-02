using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pmdi.Areas.Identity.Data
{
    public class TypeUser
    {
        [Key]
        public int idTypeUsers { get; set; }
        public string Name { get; set; }
    }

    public class WebAppUser : IdentityUser<Guid>
    {
        [StringLength(100)]
        [PersonalData]
        [Required] // Data annotations needed to configure as required
        public string FirstName { get; set; }

        [StringLength(100)]
        [PersonalData]
        [Required]
        public string LastName { get; set; } // Data annotations needed to configure as required

        [StringLength(100)]
        [PersonalData]
        public string MiddleName { get; set; } // Optional by convention

        [Comment("Date of Birth")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime DOB { get; set; }

        [Comment("Type user - Patient or Doctor")]
        public TypeUser UserType { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeFK { get; set; }
    }
}
