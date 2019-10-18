using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfTimePerformance() => Count<TimePerformance>();
        public List<TimePerformanceGetDto> SelectTimePerformance(QueryOptions options) => Select<TimePerformance, TimePerformanceGetDto>(options);
        public List<TimePerformanceGetDto> GetAllTimePerformance() => GetAll<TimePerformance, TimePerformanceGetDto>();
        public TimePerformanceGetDto GetTimePerformanceById(object id) => GetById<TimePerformance, TimePerformanceGetDto>(id);
        public TimePerformanceGetDto AddTimePerformance(TimePerformanceAddDto obj) => Add<TimePerformance, TimePerformanceGetDto, TimePerformanceAddDto>(obj);
        public TimePerformanceGetDto ChangeTimePerformance(object id, TimePerformanceChangeDto obj) => Change<TimePerformance, TimePerformanceGetDto, TimePerformanceChangeDto>(id, obj);
        public TimePerformanceGetDto RemoveTimePerformance(object id) => Remove<TimePerformance, TimePerformanceGetDto>(id);
        public void AddTimePerformanceByExcel(string path)
        {
            Business.AddTimePerformanceByExcel(path);
        }
    }
}