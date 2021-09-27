using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USERID = System.Guid;

namespace pmdi.Areas.Identity.Data
{
    public class WebAppRole : IdentityRole<USERID>
    {
        public WebAppRole() : base()
        {

        }
        public WebAppRole(string roleName): base(roleName)
        {

        }
    }
}
