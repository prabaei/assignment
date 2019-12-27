using assignment.Model.core.common;
using assignment.Model.repo.data.assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace assignment.Application.common
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
        protected  HttpResponseMessage GetResponseMes()
        {
            //if(_ErrorOccured)
            return new HttpResponseMessage(_ErrorOccured==true?System.Net.HttpStatusCode.InternalServerError:System.Net.HttpStatusCode.OK) {
                Content  = new StringContent(
 Newtonsoft.Json.JsonConvert.SerializeObject(_ErrorOccured==true?new { error=_InternalServererror} :_responseBody), System.Text.Encoding.UTF8,
"application/json"),
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
