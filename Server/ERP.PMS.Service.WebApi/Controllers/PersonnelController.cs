using ERP.PMS.Shared.Models;
using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("Personnel")]
    public class PersonnelController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<PersonnelGetDto>> GetAll() => new OperationResultCount<List<PersonnelGetDto>>()
        {
            Data = Controller.GetAllPersonnel(),
            Count = Controller.CountOfPersonnel()
        };
        [HttpPost]
        public OperationResult<PersonnelGetDto> GetById(int id) => Controller.GetPersonnelById(id);

        [HttpPost]
        public OperationResult<PersonnelGetDto> Add(PersonnelAddDto obj) => Controller.AddPersonnel(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<PersonnelGetDto> Change(int id, PersonnelChangeDto obj) => Controller.ChangePersonnel(id, obj);

        [HttpDelete]
        public OperationResult<PersonnelGetDto> Delete(int id) => Controller.RemovePersonnel(id);
    }
}