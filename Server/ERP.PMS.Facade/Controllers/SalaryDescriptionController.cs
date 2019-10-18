using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfSalaryDescription() => Count<SalaryDescription>();
        public List<SalaryDescriptionGetDto> SelectSalaryDescription(QueryOptions options) => Select<SalaryDescription, SalaryDescriptionGetDto>(options);
        public List<SalaryDescriptionGetDto> GetAllSalaryDescription() => GetAll<SalaryDescription, SalaryDescriptionGetDto>();
        public SalaryDescriptionGetDto GetSalaryDescriptionById(object id) => GetById<SalaryDescription, SalaryDescriptionGetDto>(id);
        public SalaryDescriptionGetDto AddSalaryDescription(SalaryDescriptionAddDto obj) => Add<SalaryDescription, SalaryDescriptionGetDto, SalaryDescriptionAddDto>(obj);
        public SalaryDescriptionGetDto ChangeSalaryDescription(object id, SalaryDescriptionChangeDto obj) => Change<SalaryDescription, SalaryDescriptionGetDto, SalaryDescriptionChangeDto>(id, obj);
        public SalaryDescriptionGetDto RemoveSalaryDescription(object id) => Remove<SalaryDescription, SalaryDescriptionGetDto>(id);
    }
}