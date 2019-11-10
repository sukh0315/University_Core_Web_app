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

    //GETS The details of the allocation
    public class DetailsModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DetailsModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Holds the allocation .
        public Allocation Allocation { get; set; }

        //Gets the allocation details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Allocation =  _context.Allocation
                .Include(a => a.Department)
                .Include(a => a.Lecturer)
                .Include(a => a.Module).FirstOrDefault(m => m.Id == id);

            if (Allocation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
