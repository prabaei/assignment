using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using assignment.Application.common;
using assignment.Model.api;
using assignment.Model.core.common;
using assignment.Model.repo.data.assignment;

namespace assignment.Application
{
   public class employeeRoleRepo : ResponseObject, IemployeeRoleRepo
    {
        
        public employeeRoleRepo(Idbcontext assignmentContext):base(assignmentContext)
        {
            //this._assignmentContext = assignmentContext;
        }
        

        public void Delete(int data)
        {
            var _tobeDeleted=_assignmentContext.tblempRoles.Where(m => m.id == data).SingleOrDefault();
            if (_tobeDeleted != null)
            {
                _assignmentContext.tblempRoles.Remove(_tobeDeleted);

            }
            if (save())
            {
                _responseBody = _tobeDeleted;
            }
        }

        public IemployeeRole get()
        {
            var rec=_assignmentContext.tblempRoles.Select(m => new employeeRoles() { employeeRole = m.employeeRole, id = m.id }).FirstOrDefault();
            var pure=(IemployeeRole)rec;
            return pure;
        }

        public IemployeeRole getKeyRecord(int key)
        {
            return this._assignmentContext.tblempRoles.Select(m => new employeeRoles() { employeeRole = m.employeeRole, id = m.id }).Where(m=>m.id==key).FirstOrDefault();
        }

        public override IResponseContextObject getResponseContext()
        {
            return base.getResponseContext();
        }

        public HttpResponseMessage GetResponseMessage()
        {
            return base.GetResponseMes();
        }

        public void Insert(IemployeeRole data)
        {
            _assignmentContext.tblempRoles.Add(new tblempRole() { employeeRole = data.employeeRole });
         
            if (save())
            {
                data.id  = _assignmentContext.Database.SqlQuery<int>("select cast(isnull(IDENT_CURRENT('tblempRole'),0)as int)").SingleOrDefault();
                _responseBody = data;
            }
        }

        public IEnumerable<IemployeeRole> List()
        {
            return this._assignmentContext.tblempRoles.Select(m=>new employeeRoles() {employeeRole=m.employeeRole,id=m.id }).ToList();
            
        }

        public void Update(IemployeeRole data)
        {
            var _record = _assignmentContext.tblempRoles.Where(m => m.id == data.id).SingleOrDefault();
            if (_record != null)
            {
                _record.employeeRole = data.employeeRole;
            }
            if (save())
            {
                //return getKeyRecord(1);
                _responseBody = data;
            }
        }

       
        
    }
}
