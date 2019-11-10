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
    //Gets all departments 
    public class IndexModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public IndexModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Holds department list.
        public IList<Department> Department { get;set; }

        //Gets all departments using a linq query.
        public void  OnGet()
        {
            Department = (from department in _context.Department
                          select department).ToList();
        }
    }
}
