using ERP.PMS.Shared.Models;
using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("PersonnelStatus")]
    public class PersonnelStatusController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<PersonnelStatusGetDto>> GetAll() => new OperationResultCount<List<PersonnelStatusGetDto>>()
        {
            Data = Controller.GetAllPersonnelStatus(),
            Count = Controller.CountOfPersonnelStatus()
        };
        [HttpPost]
        public OperationResult<PersonnelStatusGetDto> GetById(int id) => Controller.GetPersonnelStatusById(id);

        [HttpPost]
        public OperationResult<PersonnelStatusGetDto> Add(PersonnelStatusAddDto obj) => Controller.AddPersonnelStatus(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<PersonnelStatusGetDto> Change(int id, PersonnelStatusChangeDto obj) => Controller.ChangePersonnelStatus(id, obj);

        [HttpDelete]
        public OperationResult<PersonnelStatusGetDto> Delete(int id) => Controller.RemovePersonnelStatus(id);
    }
}