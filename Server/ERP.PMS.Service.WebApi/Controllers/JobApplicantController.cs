using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("JobApplicant")]
    public class JobApplicantController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<JobApplicantGetDto>> GetAll() => new OperationResultCount<List<JobApplicantGetDto>>()
        {
            Data = Controller.GetAllJobApplicant(),
            Count = Controller.CountOfJobApplicant()
        };
        [HttpPost]
        public OperationResult<JobApplicantGetDto> GetById(int id) => Controller.GetJobApplicantById(id);

        [HttpPost]
        public OperationResult<JobApplicantGetDto> Add(JobApplicantAddDto obj) => Controller.AddJobApplicant(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<JobApplicantGetDto> Change(int id, JobApplicantChangeDto obj) => Controller.ChangeJobApplicant(id, obj);

        [HttpDelete]
        public OperationResult<JobApplicantGetDto> Delete(int id) => Controller.RemoveJobApplicant(id);
    }
}