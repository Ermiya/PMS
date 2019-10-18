using ERP.PMS.Shared.Models;
using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("WorkExperience")]
    public class WorkExperienceController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<WorkExperienceGetDto>> GetAll() => new OperationResultCount<List<WorkExperienceGetDto>>()
        {
            Data = Controller.GetAllWorkExperience(),
            Count = Controller.CountOfWorkExperience()
        };
        [HttpGet]
        public OperationResult<WorkExperienceGetDto> GetById(int id) => Controller.GetWorkExperienceById(id);

        [HttpPost]
        public OperationResult<WorkExperienceGetDto> Add(WorkExperienceAddDto obj) => Controller.AddWorkExperience(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<WorkExperienceGetDto> Change(int id, WorkExperienceChangeDto obj) => Controller.ChangeWorkExperience(id, obj);

        [HttpDelete]
        public OperationResult<WorkExperienceGetDto> Delete(int id) => Controller.RemoveWorkExperience(id);
        
//        
//        [Route(""), HttpGet]
//        public OperationResultCount<List<WorkExperienceGetDto>> Select(ODataQueryOptions<WorkExperienceGetDto> options) 
//            => GetODataQueryOptionsResult<Calendar, CalendarGetDto>(Controller.Set<WorkExperienceGetDto>(), options);
    }
}