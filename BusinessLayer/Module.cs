using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Core_Web_app.BusinessLayer
{
    //A subject module.
    public class Module
    {
        //Primary key.
        public int Id { get; set; }

        //Module name .
        public string Name { get; set; }

        //Module credits.
        public int  Credits { get; set; }
    }
}
