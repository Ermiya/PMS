using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfDependant() => Count<Dependant>();
        public List<DependantGetDto> SelectDependant(QueryOptions options) => Select<Dependant, DependantGetDto>(options);
        public List<DependantGetDto> GetAllDependant() => GetAll<Dependant, DependantGetDto>();
        public DependantGetDto GetDependantById(object id) => GetById<Dependant, DependantGetDto>(id);
        public DependantGetDto AddDependant(DependantAddDto obj) => Add<Dependant, DependantGetDto, DependantAddDto>(obj);
        public DependantGetDto ChangeDependant(object id, DependantChangeDto obj) => Change<Dependant, DependantGetDto, DependantChangeDto>(id, obj);
        public DependantGetDto RemoveDependant(object id) => Remove<Dependant, DependantGetDto>(id);
    }
}