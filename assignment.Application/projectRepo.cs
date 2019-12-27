using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using assignment.Model.api;
using assignment.Model.repo.data.assignment;

namespace assignment.Application
{
    public class projectRepo : common.ResponseObject, IprojectRepo
    {

        public projectRepo(Idbcontext assignmentcontext) : base(assignmentcontext) { }
        public void Delete(int data)
        {
            var _tobedeleted=_assignmentContext.tblProjects.Where(m => m.projectId == data).SingleOrDefault();
            if (_tobedeleted != null)
               _assignmentContext.tblProjects.Remove(_tobedeleted);
            if (save())
            {
                _responseBody = _tobedeleted;

            }
        }

        public ItblProject get()
        {
            return this._assignmentContext.tblProjects.Select(m=>new Model.api.tblproject() {modifiedOn=m.modifiedOn,active=m.active,assignee=m.assignee,createdOn=m.createdOn,progress=m.progress,projectId=m.projectId,projectStatus=m.projectStatus,projectTitle=m.projectTitle }).FirstOrDefault();
        }

        public ItblProject getKeyRecord(int key)
        {
            return this._assignmentContext.tblProjects.Select(m => new Model.api.tblproject() { modifiedOn = m.modifiedOn, active = m.active, assignee = m.assignee, createdOn = m.createdOn, progress = m.progress, projectId = m.projectId, projectStatus = m.projectStatus, projectTitle = m.projectTitle }).Where(m => m.projectId == key).FirstOrDefault();
        }

        public HttpResponseMessage GetResponseMessage()
        {
            return base.GetResponseMes();
        }

        public void Insert(ItblProject data)
        {
            _assignmentContext.tblProjects.Add(new tblProject() { active = true, assignee = data.assignee, createdOn = DateTime.Now, modifiedOn = DateTime.Now, progress = 1, projectStatus = 1, projectTitle = data.projectTitle });
            if (save())
            {
                _responseBody = data;

            }
        }

        public IEnumerable<ItblProject> List()
        {
            return this._assignmentContext.tblProjects.Select(m => new Model.api.tblproject() { modifiedOn = m.modifiedOn, active = m.active, assignee = m.assignee, createdOn = m.createdOn, progress = m.progress, projectId = m.projectId, projectStatus = m.projectStatus, projectTitle = m.projectTitle }).ToList();
        }

        public void Update(ItblProject data)
        {
            var _tobeUpdated = _assignmentContext.tblProjects.Where(m => m.projectId == data.projectId).SingleOrDefault();

            if (_tobeUpdated != null)
                _tobeUpdated.active = true; _tobeUpdated.assignee = data.assignee;_tobeUpdated.modifiedOn = DateTime.Now; _tobeUpdated.progress = data.progress; _tobeUpdated.projectStatus = data.projectStatus; _tobeUpdated.projectTitle = data.projectTitle ;
            if (save())
            {
                _responseBody = _tobeUpdated;

            }
        }
    }
}
