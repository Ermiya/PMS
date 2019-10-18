using System.Collections.Generic;
using Bitspco.Framework.Common.Query;
using ERP.PMS.Common.Entities;
using ERP.PMS.Shared.Models;

namespace ERP.PMS.Facade
{
    public partial class PMSController
    {
        public int CountOfContract() => Count<Contract>();
        public List<ContractGetDto> SelectContract(QueryOptions options) => Select<Contract, ContractGetDto>(options);
        public List<ContractGetDto> GetAllContract() => GetAll<Contract, ContractGetDto>();
        public ContractGetDto GetContractById(object id) => GetById<Contract, ContractGetDto>(id);
        public ContractGetDto AddContract(ContractAddDto obj) => Add<Contract, ContractGetDto, ContractAddDto>(obj);
        public ContractGetDto ChangeContract(object id, ContractChangeDto obj) => Change<Contract, ContractGetDto, ContractChangeDto>(id, obj);
        public ContractGetDto RemoveContract(object id) => Remove<Contract, ContractGetDto>(id);
    }
}