﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Core_Web_app.BusinessLayer
{
    //A department
    public class Department
    {
        //Primary key.
        public int Id { get; set; }

        //Department name.
        public string Name { get; set; }

        //Department email.
        public string DepartmentEmail { get; set; }
    }
}
