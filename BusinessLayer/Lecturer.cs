using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Core_Web_app.BusinessLayer
{
    //A lecturer 
    public class Lecturer
    {
        //Primary key.
        public int Id { get; set; }

        //Lecturer name.
        public string Name { get; set; }

        //Lecturer email.
        public string Email { get; set; }

    }
}
