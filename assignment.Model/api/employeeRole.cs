using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
    public class employeeRole : IemployeeRole
    {
        public int id
        {
            get;

            set;
        }

        string IemployeeRole.employeeRole
        {
            get;

            set;
        }
    }
}
