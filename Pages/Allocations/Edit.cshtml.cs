using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;
using University_Core_Web_app.Models;

namespace University_Core_Web_app.Pages.Allocations
{
    //Updates the allocation.
    public class EditModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public EditModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Binds the allocation model.
        [BindProperty]
        public Allocation Allocation { get; set; }

        //Gets the allocation for update using a lamda query
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
           ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Name", Allocation.DepartmentId);
           ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Name", Allocation.LecturerId);
           ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Name", Allocation.ModuleId);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Update the allocation.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Allocation).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllocationExists(Allocation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the allocation exists using  a lamlda query.
        private bool AllocationExists(int id)
        {
            return _context.Allocation.Any(e => e.Id == id);
        }
    }
}
