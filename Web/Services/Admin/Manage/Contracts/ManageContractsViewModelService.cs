using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Interfaces;
using Web.Interfaces.Admin.Manage.Contracts;
using Web.ViewModels.Admin.Manage.Contracts;

namespace Web.Services.Admin.Manage.Contracts
{
    public class ManageContractsViewModelService : IManageContractsViewModelService
    {
        private readonly IRepository<EmployeeContract> _employeeContractRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public ManageContractsViewModelService(IRepository<EmployeeContract> employeeContractRepository, IRepository<Employee> employeeRepository)
        {
            _employeeContractRepository = employeeContractRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<IndexViewModel> getViewModel()
        {
            var contracts = await _employeeContractRepository.ListAsync();
            var employees = await _employeeRepository.ListAsync();

            var vm = new IndexViewModel()
            {
                EmployeeContracts = contracts.Select(x => new IndexItemViewModel
                {
                    Id = x.Id,
                    Employee = x.Employee,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,

                }).ToList(),

            };

            return vm;
        }

    }
}
