using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
    public class employeeRoles : IemployeeRole
    {
        public int id
        {
            get;

            set;
        }

        [Required]
        public string employeeRole
        {
            get;

            set;
        }
    }
}
