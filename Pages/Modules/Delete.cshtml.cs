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
    //Removes a module from databse.
    public class DeleteModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public DeleteModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Binds the module 
        [BindProperty]
        public Module Module { get; set; }

        //Gets the module for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module =  _context.Module.FirstOrDefault(m => m.Id == id);

            if (Module == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the module from db uses  a linq query to select the module.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Module = (from module in _context.Module
                      where module.Id == id
                      select module).FirstOrDefault();

            if (Module != null)
            {
                _context.Module.Remove(Module);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
