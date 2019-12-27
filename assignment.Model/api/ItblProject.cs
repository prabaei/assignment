using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.api
{
   public interface ItblProject
    {
        int projectId { get; set; }

        string projectTitle { get; set; }

        int assignee { get; set; }

        int projectStatus { get; set; }

        decimal progress { get; set; }

        DateTime createdOn { get; set; }

        DateTime modifiedOn { get; set; }

        bool? active { get; set; }
    }
}
