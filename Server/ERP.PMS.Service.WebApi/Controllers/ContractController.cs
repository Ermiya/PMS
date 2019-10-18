using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("Contract")]
    public class ContractController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<ContractGetDto>> GetAll() => new OperationResultCount<List<ContractGetDto>>()
            {
                Data = Controller.GetAllContract(),
                Count = Controller.CountOfContract()
            };
        [HttpGet]
        public OperationResult<ContractGetDto> GetById(int id) => Controller.GetContractById(id);

        [HttpPost]
        public OperationResult<ContractGetDto> Add(ContractAddDto obj) => Controller.AddContract(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<ContractGetDto> Change(int id, ContractChangeDto obj) => Controller.ChangeContract(id, obj);

        [HttpDelete]
        public OperationResult<ContractGetDto> Delete(int id) => Controller.RemoveContract(id);

    }
}