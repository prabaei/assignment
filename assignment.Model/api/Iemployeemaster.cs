using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
    public interface Iemployeemaster
    {
      
         int empId { get; set; }

       
         string name { get; set; }

        
         string mobile { get; set; }

         int employeeRole { get; set; }

         DateTime createdOn { get; set; }

         DateTime modifiedOn { get; set; }

         bool? active { get; set; }
    }
}
