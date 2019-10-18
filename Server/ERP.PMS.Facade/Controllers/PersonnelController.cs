using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;
using System.Collections.Generic;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfPersonnel() => Count<Personnel>();
        public List<PersonnelGetDto> SelectPersonnel(QueryOptions options) => Select<Personnel, PersonnelGetDto>(options);
        public List<PersonnelGetDto> GetAllPersonnel() => GetAll<Personnel, PersonnelGetDto>();
        public PersonnelGetDto GetPersonnelById(object id) => GetById<Personnel, PersonnelGetDto>(id);
        public PersonnelGetDto AddPersonnel(PersonnelAddDto obj) => Add<Personnel, PersonnelGetDto, PersonnelAddDto>(obj);
        public PersonnelGetDto ChangePersonnel(object id, PersonnelChangeDto obj) => Change<Personnel, PersonnelGetDto, PersonnelChangeDto>(id, obj);
        public PersonnelGetDto RemovePersonnel(object id) => Remove<Personnel, PersonnelGetDto>(id);
    }
}