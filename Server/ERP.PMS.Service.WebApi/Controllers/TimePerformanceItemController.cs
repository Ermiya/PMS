using ERP.PMS.Shared.Models;
using System.Collections.Generic;
using System.Web.Http;
using Bitspco.Framework.Common;

namespace ERP.PMS.Service.WebApi.Controllers
{
    [RoutePrefix("TimePerformanceItem")]
    public class TimePerformanceItemController : ApiController
    {
        [HttpGet]
        public OperationResultCount<List<TimePerformanceItemGetDto>> GetAll() => new OperationResultCount<List<TimePerformanceItemGetDto>>()
        {
            Data = Controller.GetAllTimePerformanceItem(),
            Count = Controller.CountOfTimePerformanceItem()
        };
        [HttpPost]
        public OperationResult<TimePerformanceItemGetDto> GetById(int id) => Controller.GetTimePerformanceItemById(id);

        [HttpPost]
        public OperationResult<TimePerformanceItemGetDto> Add(TimePerformanceItemAddDto obj) => Controller.AddTimePerformanceItem(obj);

        [HttpPut, Route("{id:int}")]
        public OperationResult<TimePerformanceItemGetDto> Change(int id, TimePerformanceItemChangeDto obj) => Controller.ChangeTimePerformanceItem(id, obj);

        [HttpDelete]
        public OperationResult<TimePerformanceItemGetDto> Delete(int id) => Controller.RemoveTimePerformanceItem(id);
    }
}