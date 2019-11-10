using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University_Core_Web_app.BusinessLayer;

namespace University_Core_Web_app.Models
{
    //Connects the business layer classes to the databse.
    public class University_Core_Web_appDataContext : DbContext
    {
        public University_Core_Web_appDataContext (DbContextOptions<University_Core_Web_appDataContext> options)
            : base(options)
        {
        }

        public DbSet<University_Core_Web_app.BusinessLayer.Allocation> Allocation { get; set; }

        public DbSet<University_Core_Web_app.BusinessLayer.Department> Department { get; set; }

        public DbSet<University_Core_Web_app.BusinessLayer.Lecturer> Lecturer { get; set; }

        public DbSet<University_Core_Web_app.BusinessLayer.Module> Module { get; set; }
    }
}
