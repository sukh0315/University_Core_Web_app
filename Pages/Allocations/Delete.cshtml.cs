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
    //Delets the allocation form the databse.
    public class DeleteModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DeleteModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Binds the allocation model.
        [BindProperty]
        public Allocation Allocation { get; set; }


        //Gets the allocation model for delete using a lamda query.
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

        //Deletes the allocation model uses a linq query to slect the allocation.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Allocation = (from allocation in _context.Allocation
                          where allocation.Id == id
                          select allocation).FirstOrDefault();

            if (Allocation != null)
            {
                _context.Allocation.Remove(Allocation);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
