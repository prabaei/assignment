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
            return Ok(this._EmployeeRepo.List());
        }

        // GET: api/Employee/5
        public IHttpActionResult Get(int id)
        {
            return Ok(this._EmployeeRepo.getKeyRecord(id));
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]employeemaster value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            this._EmployeeRepo.Insert(value);
            return _EmployeeRepo.GetResponseMessage();

        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put(int id, [FromBody]employeemaster value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            value.empId = id;
            _EmployeeRepo.Update(value);
            return _EmployeeRepo.GetResponseMessage();
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)
        {
            this._EmployeeRepo.Delete(id);
            return _EmployeeRepo.GetResponseMessage();
        }
    }
}
