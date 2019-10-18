using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfSalaryContract() => Count<SalaryContract>();
        public List<SalaryContractGetDto> SelectSalaryContract(QueryOptions options) => Select<SalaryContract, SalaryContractGetDto>(options);
        public List<SalaryContractGetDto> GetAllSalaryContract() => GetAll<SalaryContract, SalaryContractGetDto>();
        public SalaryContractGetDto GetSalaryContractById(object id) => GetById<SalaryContract, SalaryContractGetDto>(id);
        public SalaryContractGetDto AddSalaryContract(SalaryContractAddDto obj) => Add<SalaryContract, SalaryContractGetDto, SalaryContractAddDto>(obj);
        public SalaryContractGetDto ChangeSalaryContract(object id, SalaryContractChangeDto obj) => Change<SalaryContract, SalaryContractGetDto, SalaryContractChangeDto>(id, obj);
        public SalaryContractGetDto RemoveSalaryContract(object id) => Remove<SalaryContract, SalaryContractGetDto>(id);
    }
}