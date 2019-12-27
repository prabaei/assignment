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
    public class ProjectController : ApiController
    {
        readonly IprojectRepo _projectRepo;
        public ProjectController(IprojectRepo projectRepo) {
            _projectRepo = projectRepo;
        }
        // GET: api/Project
        public IHttpActionResult Get()
        {
            return Ok( _projectRepo.List());
        }

        // GET: api/Project/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_projectRepo.getKeyRecord(id));
        }

        // POST: api/Project
        public HttpResponseMessage Post([FromBody]tblproject value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            _projectRepo.Insert(value);
            return _projectRepo.GetResponseMessage();
        }

        // PUT: api/Project/5
        public HttpResponseMessage Put(int id, [FromBody]tblproject value)
        {
            if (value == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "value passed is not valid");
            value.projectId = id;
            _projectRepo.Update(value);
            return _projectRepo.GetResponseMessage();
        }

        // DELETE: api/Project/5
        public HttpResponseMessage Delete(int id)
        {
            _projectRepo.Delete(id);

            return _projectRepo.GetResponseMessage();
        }
    }
}
