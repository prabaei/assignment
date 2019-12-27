using assignment.Application;
using assignment.Model.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assignment.Controllers
{
    public class employeeRoleController : ApiController
    {
        readonly IemployeeRoleRepo _employeeRepo;

        public employeeRoleController(IemployeeRoleRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        // GET: api/employeeRole
        public IHttpActionResult Get()
        {

            return Ok(_employeeRepo.List());
        }

        // GET: api/employeeRole/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_employeeRepo.getKeyRecord(id));
        }

        // POST: api/employeeRole
        public HttpResponseMessage Post([FromBody]assignment.Model.api.employeeRoles value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            _employeeRepo.Insert(value);
            return _employeeRepo.GetResponseMessage();
        }

        // PUT: api/employeeRole/5
        public HttpResponseMessage Put(int id, [FromBody]employeeRoles value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            value.id = id;
            _employeeRepo.Update(value);
            return _employeeRepo.GetResponseMessage();
        }

        // DELETE: api/employeeRole/5
        public HttpResponseMessage Delete(int id=0)
        {
            _employeeRepo.Delete(id);

            return _employeeRepo.GetResponseMessage();
        }
        //[HttpGet]
        //public IHttpActionResult List()
        //{
            
        //}
    }
}
