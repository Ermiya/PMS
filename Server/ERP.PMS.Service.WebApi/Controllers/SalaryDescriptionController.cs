using ERP.PMS.Shared.Models;
using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("SalaryDescription")]
    public class SalaryDescriptionController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<SalaryDescriptionGetDto>> GetAll() => new OperationResultCount<List<SalaryDescriptionGetDto>>()
        {
            Data = Controller.GetAllSalaryDescription(),
            Count = Controller.CountOfSalaryDescription()
        };
        [HttpPost]
        public OperationResult<SalaryDescriptionGetDto> GetById(int id) => Controller.GetSalaryDescriptionById(id);

        [HttpPost]
        public OperationResult<SalaryDescriptionGetDto> Add(SalaryDescriptionAddDto obj) => Controller.AddSalaryDescription(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<SalaryDescriptionGetDto> Change(int id, SalaryDescriptionChangeDto obj) => Controller.ChangeSalaryDescription(id, obj);

        [HttpDelete]
        public OperationResult<SalaryDescriptionGetDto> Delete(int id) => Controller.RemoveSalaryDescription(id);
    }
}