using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
    public class ResponseContextObject : IResponseContextObject
    {
        public string InternalServererror { get; set; }
        public bool ErrorOccured { get; set; }
        public object responseBody { get; set; }
    }
}
