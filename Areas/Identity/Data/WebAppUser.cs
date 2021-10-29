using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using USERID = System.Guid;

namespace pmdi.Areas.Identity.Data
{
    public class WebAppUser : IdentityUser<USERID>
    {
        public WebAppUser():base()
        {

        }

        public WebAppUser(string userName):base(userName)
        {

        }

        [StringLength(100)]
        [PersonalData]
        [Required] // Data annotations needed to configure as required
        public string FullName { get; set; }

        //[StringLength(100)]
        //[PersonalData]
        //[Required]
        //public string LastName { get; set; } // Data annotations needed to configure as required

        //[StringLength(100)]
        //[PersonalData]
        //public string MiddleName { get; set; } // Optional by convention

        [Comment("Date of Birth")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
