using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Modules
{
    //Details of the module.
    public class DetailsModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DetailsModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Holds the module.
        public Module Module { get; set; }

        //Gets the module details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = _context.Module.FirstOrDefault(m => m.Id == id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
