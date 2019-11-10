using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Departments
{
    //Removes the department from the database.
    public class DeleteModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DeleteModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Binds the department model.
        [BindProperty]
        public Department Department { get; set; }

        //Gets the department for delete using  a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department =  _context.Department.FirstOrDefault(m => m.Id == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the department uses a linq query to select the department.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = (from department in _context.Department
                          where department.Id == id
                          select department).FirstOrDefault();

            if (Department != null)
            {
                _context.Department.Remove(Department);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
