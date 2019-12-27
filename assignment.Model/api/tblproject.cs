using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
    public class tblproject:ItblProject
    {
       public int projectId { get; set; }

        public string projectTitle { get; set; }

        public int assignee { get; set; }

        public int projectStatus { get; set; }

        public decimal progress { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime modifiedOn { get; set; }

        public bool? active { get; set; }
    }
}
