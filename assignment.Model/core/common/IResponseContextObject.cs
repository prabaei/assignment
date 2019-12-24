using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
    public interface IResponseContextObject
    {
        string InternalServererror { get; set; }
        bool ErrorOccured { get; set; }
        object responseBody { get; set; }

    }
   

}
