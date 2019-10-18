using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfWorkExperience() => Count<WorkExperience>();
        public List<WorkExperienceGetDto> SelectWorkExperience(QueryOptions options) => Select<WorkExperience, WorkExperienceGetDto>(options);
        public List<WorkExperienceGetDto> GetAllWorkExperience() => GetAll<WorkExperience, WorkExperienceGetDto>();
        public WorkExperienceGetDto GetWorkExperienceById(object id) => GetById<WorkExperience, WorkExperienceGetDto>(id);
        public WorkExperienceGetDto AddWorkExperience(WorkExperienceAddDto obj) => Add<WorkExperience, WorkExperienceGetDto, WorkExperienceAddDto>(obj);
        public WorkExperienceGetDto ChangeWorkExperience(object id, WorkExperienceChangeDto obj) => Change<WorkExperience, WorkExperienceGetDto, WorkExperienceChangeDto>(id, obj);
        public WorkExperienceGetDto RemoveWorkExperience(object id) => Remove<WorkExperience, WorkExperienceGetDto>(id);
    }
}