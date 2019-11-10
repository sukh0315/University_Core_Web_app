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
    //Removes the lecturer from the databse.
    public class DeleteModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DeleteModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Binds the lecturer model.
        [BindProperty]
        public Lecturer Lecturer { get; set; }

        //Gets the lecturer for delete using a lamda query.
        public IActionResult  OnGet(int? id)
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

        //Deletes the lecturer from the databse uses a linq query to select the lecturer
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lecturer = (from lecturer in _context.Lecturer
                        where lecturer.Id == id
                        select lecturer).FirstOrDefault();

            if (Lecturer != null)
            {
                _context.Lecturer.Remove(Lecturer);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
