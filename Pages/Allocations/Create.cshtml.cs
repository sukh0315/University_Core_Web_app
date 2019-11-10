using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Allocations
{
    //Creates  an allocation
    public class CreateModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public CreateModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Gets the create allocation form.
        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Name");
        ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Name");
        ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Name");
            return Page();
        }

        //Binds the allocation model.
        [BindProperty]
        public Allocation Allocation { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

       //Adds the allocation to the database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Allocation.Add(Allocation);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
