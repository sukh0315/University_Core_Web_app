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
    //Gets all lecturers 
    public class IndexModel : PageModel
    {
        private readonly University_Core_Web_app.Models.University_Core_Web_appDataContext _context;

        public IndexModel(University_Core_Web_app.Models.University_Core_Web_appDataContext context)
        {
            _context = context;
        }

        //Lecturer list.
        public IList<Lecturer> Lecturer { get;set; }

        //Gets all lecturers using a linq query.
        public void  OnGet()
        {
            Lecturer = (from lecturers in _context.Lecturer
                        select lecturers).ToList();
        }
    }
}
