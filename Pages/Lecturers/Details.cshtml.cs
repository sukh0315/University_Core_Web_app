using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Lecturers
{
    //Gets the details of the lecturer.
    public class DetailsModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DetailsModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Holds the lecturer 
        public Lecturer Lecturer { get; set; }

        //Gets the details of the lecturer using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lecturer = _context.Lecturer.FirstOrDefault(m => m.Id == id);

            if (Lecturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
