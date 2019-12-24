using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment.Model.repo.data.assignment;
using assignment.Model.core.common;
using assignment.Model.api;
using System.Net.Http;

namespace assignment.Application
{
    public class employeeRepo : ResponseObject, IemployeeRepo
    {

        public employeeRepo(Idbcontext dbcontext) : base(dbcontext)
        {

        }


        public void Delete(int key)
        {

            var _tobedelete = _assignmentContext.tblEmployeeMasters.Where(m => m.empId == key).FirstOrDefault();
            if (_tobedelete != null)
            {
                _assignmentContext.tblEmployeeMasters.Remove(_tobedelete);
            }
            if (save())
            {
                _responseBody = _tobedelete;
            }


        }

        public Iemployeemaster get()
        {
            return _assignmentContext.tblEmployeeMasters.FirstOrDefault();
        }

        public Iemployeemaster getKeyRecord(int key)
        {
            return _assignmentContext.tblEmployeeMasters.Where(m => m.empId == key).FirstOrDefault();
        }

        public override IResponseContextObject getResponseContext()
        {
            return  base.getResponseContext();
        }

        public void Insert(Iemployeemaster data)
        {
            _assignmentContext.tblEmployeeMasters.Add(new tblEmployeeMaster()
            {
                active = true,
                createdOn = DateTime.Now,
                employeeRole = data.employeeRole,
                mobile = data.mobile,
                modifiedOn = DateTime.Now,
                name = data.name
            });
            if (save())
            {
                data.empId = _assignmentContext.Database.SqlQuery<int>("select cast(isnull(IDENT_CURRENT('tblEmployeeMaster'),0)as int)").SingleOrDefault();
                _responseBody = data;
            }
           
        }
        
        public IEnumerable<Iemployeemaster> List()
        {
            return _assignmentContext.tblEmployeeMasters.ToList();
        }
        public void Update(Iemployeemaster data)
        {
            var _toBeUpdated = _assignmentContext.tblEmployeeMasters.Where(m => m.empId == data.empId).FirstOrDefault();
            if (_toBeUpdated != null)
            {
                _toBeUpdated.active = data.active;
                _toBeUpdated.employeeRole = data.employeeRole;
                _toBeUpdated.mobile = data.mobile;
                _toBeUpdated.modifiedOn = DateTime.Now;
                _toBeUpdated.name = data.name;
                //_toBeUpdated.

            }
            if (save())
            {
                _responseBody = data;
            }
          
        }


    }
}
