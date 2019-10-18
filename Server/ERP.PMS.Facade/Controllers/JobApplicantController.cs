using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfJobApplicant() => Count<JobApplicant>();
        public List<JobApplicantGetDto> SelectJobApplicant(QueryOptions options) => Select<JobApplicant, JobApplicantGetDto>(options);
        public List<JobApplicantGetDto> GetAllJobApplicant() => GetAll<JobApplicant, JobApplicantGetDto>();
        public JobApplicantGetDto GetJobApplicantById(object id) => GetById<JobApplicant, JobApplicantGetDto>(id);
        public JobApplicantGetDto AddJobApplicant(JobApplicantAddDto obj) => Add<JobApplicant, JobApplicantGetDto, JobApplicantAddDto>(obj);
        public JobApplicantGetDto ChangeJobApplicant(object id, JobApplicantChangeDto obj) => Change<JobApplicant, JobApplicantGetDto, JobApplicantChangeDto>(id, obj);
        public JobApplicantGetDto RemoveJobApplicant(object id) => Remove<JobApplicant, JobApplicantGetDto>(id);
    }
}