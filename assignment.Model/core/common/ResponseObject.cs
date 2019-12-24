using assignment.Model.repo.data.assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Model.core.common
{
   public class ResponseObject
    {
        public ResponseObject(Idbcontext assignmentContext)
        {
            this._assignmentContext = assignmentContext;
        }
        protected readonly Idbcontext _assignmentContext;
        protected string _InternalServererror { get; set; }
        protected bool _ErrorOccured { get; set; }
        protected object _responseBody { get; set; }
        public virtual IResponseContextObject getResponseContext()
        {
            return new ResponseContextObject() {
                ErrorOccured=_ErrorOccured,
                InternalServererror=_InternalServererror,
                responseBody=_responseBody
            };
        }
        protected virtual bool save()
        {
            try
            {
                _assignmentContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _ErrorOccured = true;
                _InternalServererror = ex.Message;
                return false;
            }
        }
    }
}
