using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfPersonnelStatus() => Count<PersonnelStatus>();
        public List<PersonnelStatusGetDto> SelectPersonnelStatus(QueryOptions options) => Select<PersonnelStatus, PersonnelStatusGetDto>(options);
        public List<PersonnelStatusGetDto> GetAllPersonnelStatus() => GetAll<PersonnelStatus, PersonnelStatusGetDto>();
        public PersonnelStatusGetDto GetPersonnelStatusById(object id) => GetById<PersonnelStatus, PersonnelStatusGetDto>(id);
        public PersonnelStatusGetDto AddPersonnelStatus(PersonnelStatusAddDto obj) => Add<PersonnelStatus, PersonnelStatusGetDto, PersonnelStatusAddDto>(obj);
        public PersonnelStatusGetDto ChangePersonnelStatus(object id, PersonnelStatusChangeDto obj) => Change<PersonnelStatus, PersonnelStatusGetDto, PersonnelStatusChangeDto>(id, obj);
        public PersonnelStatusGetDto RemovePersonnelStatus(object id) => Remove<PersonnelStatus, PersonnelStatusGetDto>(id);
    }
}