using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfTimePerformanceItem() => Count<TimePerformanceItem>();
        public List<TimePerformanceItemGetDto> SelectTimePerformanceItem(QueryOptions options) => Select<TimePerformanceItem, TimePerformanceItemGetDto>(options);
        public List<TimePerformanceItemGetDto> GetAllTimePerformanceItem() => GetAll<TimePerformanceItem, TimePerformanceItemGetDto>();
        public TimePerformanceItemGetDto GetTimePerformanceItemById(object id) => GetById<TimePerformanceItem, TimePerformanceItemGetDto>(id);
        public TimePerformanceItemGetDto AddTimePerformanceItem(TimePerformanceItemAddDto obj) => Add<TimePerformanceItem, TimePerformanceItemGetDto, TimePerformanceItemAddDto>(obj);
        public TimePerformanceItemGetDto ChangeTimePerformanceItem(object id, TimePerformanceItemChangeDto obj) => Change<TimePerformanceItem, TimePerformanceItemGetDto, TimePerformanceItemChangeDto>(id, obj);
        public TimePerformanceItemGetDto RemoveTimePerformanceItem(object id) => Remove<TimePerformanceItem, TimePerformanceItemGetDto>(id);
    }
}