using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
    public class employeemaster: Iemployeemaster
    {
        
        public int empId { get; set; }

        [Required]
        [StringLength(80)]
        public string name { get; set; }

        [Required]
        [StringLength(80)]
        public string mobile { get; set; }

        public int employeeRole { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime modifiedOn { get; set; }

        public bool? active { get; set; }
    }
}
