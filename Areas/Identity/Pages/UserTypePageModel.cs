using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pmdi.Data;

namespace pmdi.Areas.Identity.Pages
{
    public class UserTypePageModel : PageModel
    {
        public SelectList UserTypeSL { get; set; }

        public void UserTypeDropDownList(ApplicationDbContext _context,
            object selectedTypeUser = null)
        {
            var typeUserQuery = from d in _context.TypeUsers
                                   orderby d.idTypeUsers // Sort by id.
                                   select d;

            UserTypeSL = new SelectList(typeUserQuery.AsNoTracking(),
                        "idTypeUsers", "Name", selectedTypeUser);
        }

    }
}
