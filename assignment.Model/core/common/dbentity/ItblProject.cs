using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common.dbentity
{
   public interface ItblProject : IcommonCRUD<api.ItblProject>, IgetintKey<api.ItblProject>, IdeleteintKey, IresponseContext
    {
     
       

    }
}
