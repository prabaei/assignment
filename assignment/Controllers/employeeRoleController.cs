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
            
            return Ok(_employeeRepo.get());
        }

        // GET: api/employeeRole/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _employeeRepo.getKeyRecord(id));
        }

        // POST: api/employeeRole
        public HttpResponseMessage Post([FromBody]assignment.Model.api.employeeRoles value)


        {

            if (ModelState.IsValid)
            {

           
            _employeeRepo.Insert(value);
            
            Model.core.common.IResponseContextObject res = _employeeRepo.getResponseContext(); 
            if (res.ErrorOccured)
            {
               return Request.CreateResponse(HttpStatusCode.InternalServerError, res.InternalServererror);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, res.responseBody);
            }

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState.Values);
        }

        // PUT: api/employeeRole/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/employeeRole/5
        public HttpResponseMessage Delete(int id)
        {
            _employeeRepo.Delete(id);

            Model.core.common.IResponseContextObject res = _employeeRepo.getResponseContext(); ;
            if (res.ErrorOccured)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, res.InternalServererror);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, res.responseBody);
            }
        }
    }
}
