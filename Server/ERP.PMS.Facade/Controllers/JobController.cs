using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfJob() => Count<Job>();
        public List<JobGetDto> SelectJob(QueryOptions options) => Select<Job, JobGetDto>(options);
        public List<JobGetDto> GetAllJob() => GetAll<Job, JobGetDto>();
        public JobGetDto GetJobById(object id) => GetById<Job, JobGetDto>(id);
        public JobGetDto AddJob(JobAddDto obj) => Add<Job, JobGetDto, JobAddDto>(obj);
        public JobGetDto ChangeJob(object id, JobChangeDto obj) => Change<Job, JobGetDto, JobChangeDto>(id, obj);
        public JobGetDto RemoveJob(object id) => Remove<Job, JobGetDto>(id);
    }
}