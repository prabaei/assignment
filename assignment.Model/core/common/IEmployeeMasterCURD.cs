using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
    public interface IEmployeeMasterCURD:IcommonCRUD<api.Iemployeemaster>,IgetintKey<api.Iemployeemaster>,IdeleteintKey
       // ,core.database.IdbCore
    {

    }
}
