using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Allocations
{
    //Gets all allocations.
    public class IndexModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public IndexModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //The allocation list.
        public IList<Allocation> Allocation { get;set; }

        //Gets  all allocation using a lamda query.
        public void  OnGet()
        {
            Allocation =  _context.Allocation
                .Include(a => a.Department)
                .Include(a => a.Lecturer)
                .Include(a => a.Module).ToList();
        }
    }
}
