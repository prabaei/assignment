using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment.Model.repo.data.assignment;
using assignment.Model.core.common;
using assignment.Model.api;

namespace assignment.Application
{
    public class employeeRepo : IemployeeRepo
    {
        readonly Idbcontext _dbcontext ;
       

        public employeeRepo(Idbcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public void Delete(int key)
        {
           
                 var _tobedelete= _dbcontext.tblEmployeeMasters.Where(m=>m.empId==key).FirstOrDefault();
                if (_tobedelete != null)
                {
                _dbcontext.tblEmployeeMasters.Remove(_tobedelete);
                }
                try
                {
                _dbcontext.SaveChanges();
                }
                catch(Exception ex)
                {

                }
            
        }

        public Iemployeemaster get()
        {
            return (Iemployeemaster)_dbcontext.tblEmployeeMasters.FirstOrDefault();
        }
        
        public Iemployeemaster getKeyRecord(int key)
        {
            return (Iemployeemaster)_dbcontext.tblEmployeeMasters.Where(m=>m.empId==key).FirstOrDefault();
        }

        public Iemployeemaster Insert(Iemployeemaster data)
        {
            _dbcontext.tblEmployeeMasters.Add(new tblEmployeeMaster() {
                active=true,
                createdOn=DateTime.Now,
                employeeRole=data.employeeRole,
                mobile=data.mobile,modifiedOn=DateTime.Now,
                name=data.name
            });
          
            try
            {
                _dbcontext.SaveChanges();
                data.empId=_dbcontext.Database.SqlQuery<int>("select cast(isnull(IDENT_CURRENT('tblEmployeeMaster'),0)as int)").SingleOrDefault();
                return getKeyRecord(data.empId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Iemployeemaster> List()
        {
            return _dbcontext.tblEmployeeMasters.ToList();
        }
        public void Update(Iemployeemaster data)
        {
            var _toBeUpdated = _dbcontext.tblEmployeeMasters.Where(m => m.empId == data.empId).FirstOrDefault();
            if (_toBeUpdated != null)
            {
                _toBeUpdated.active = data.active;
                _toBeUpdated.employeeRole = data.employeeRole;
                _toBeUpdated.mobile = data.mobile;
                _toBeUpdated.modifiedOn = DateTime.Now;
                _toBeUpdated.name = data.name;
                //_toBeUpdated.

            }
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
