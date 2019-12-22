using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using assignment.Model.api;
using assignment.Application;

namespace assignment.Controllers
{
    public class EmployeeController : ApiController
    {
        readonly IemployeeRepo _EmployeeRepo;
        public EmployeeController(IemployeeRepo emprepo)
        {
            this._EmployeeRepo = emprepo;
        }
        // GET: api/Employee
        public IHttpActionResult  Get()
        {
            //return new Iemployeemaster[] { new employeemaster(){ name="chumma kizi"} };
            return Ok(this._EmployeeRepo.get());
        }

        // GET: api/Employee/5
        public IHttpActionResult Get(int id)
        {
            return Ok(this._EmployeeRepo.getKeyRecord(id));
        }

        // POST: api/Employee
        public IHttpActionResult Post([FromBody]employeemaster value)
        {
            this._EmployeeRepo.Insert(value);
            return Ok(value);

        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]Iemployeemaster value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
