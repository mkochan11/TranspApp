using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications.Employee;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeContract> _employeeContractRepository;

        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<EmployeeContract> employeeContractRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeContractRepository = employeeContractRepository;

        }


        public async Task<Result> UpdateEmployeeActivityStatus(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return Result.NotFound("Employee Not Found");
            }

            var _contractSpec = new EmployeeContractFind(employeeId);
            var contracts = await _employeeContractRepository.ListAsync(_contractSpec);

            var isActive = false;
            foreach (var contract in contracts)
            {
                if (contract.IsActive())
                {
                    isActive = true; break;
                }
            }

            employee.IsActive = isActive;
            await _employeeRepository.UpdateAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return Result.Success();
        }

        
    }
}
