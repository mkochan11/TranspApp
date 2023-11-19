using ApplicationCore.Entities.EmployeeAggregate;
using ApplicationCore.Entities.VehicleAggregate;
using ApplicationCore.Interfaces;
using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class EmployeeContractService : IEmployeeContractService
    {
        private readonly IRepository<EmployeeContract> _contractsRepository;
        private readonly IEmployeeService _employeeService; 
        public EmployeeContractService(IRepository<EmployeeContract> contractsRepository, IEmployeeService employeeService)
        {
            _contractsRepository = contractsRepository;
            _employeeService = employeeService;
        }

        public async Task<Result> RenewContract(int contractId)
        {
            var oldContract = await _contractsRepository.GetByIdAsync(contractId);
            if (oldContract == null)
            {
                var res = Result.NotFound("Contract not found");
                return res;
            }
            var newContract = CreateContractObject();

            if(newContract == null)
            {
                var res = Result.Error("Could not create new Contract");
                return res;
            }
            newContract.EmployeeId = oldContract.EmployeeId;
            newContract.Salary = oldContract.Salary;
            newContract.StartDate = DateTime.Now;
            newContract.EndDate = null;

            await _contractsRepository.AddAsync(newContract);
            await _contractsRepository.SaveChangesAsync();

            var resEmpl = await _employeeService.UpdateEmployeeActivityStatus(newContract.EmployeeId);
            if (!resEmpl.IsSuccess) { 
                return Result.Error(resEmpl.Errors.ToArray());
            }
            return Result.Success();
            
        }

        public async Task<Result> TerminateContract(int contractId)
        {
            var contract = await _contractsRepository.GetByIdAsync(contractId);
            if (contract == null)
            {
                var res = Result.NotFound("Contract not found");
                return res;
            }

            contract.EndDate = DateTime.Now;
            await _contractsRepository.UpdateAsync(contract);
            await _contractsRepository.SaveChangesAsync();

            var resEmpl = await _employeeService.UpdateEmployeeActivityStatus(contract.EmployeeId);
            if (!resEmpl.IsSuccess)
            {
                return Result.Error(resEmpl.Errors.ToArray());
            }

            return Result.Success(); 
        }

        public async Task<Result> DeleteContract(int contractId)
        {
            var contract = await _contractsRepository.GetByIdAsync(contractId);
            if (contract == null)
            {
                var res = Result.NotFound("Contract not found");
                return res;
            }
            await _contractsRepository.DeleteAsync(contract);
            await _contractsRepository.SaveChangesAsync();

            var resEmpl = await _employeeService.UpdateEmployeeActivityStatus(contract.EmployeeId);
            if (!resEmpl.IsSuccess)
            {
                return Result.Error(resEmpl.Errors.ToArray());
            }

            return Result.Success();
        }

        public async Task<Result> CreateContract(int employeeId, DateTime startDate, DateTime endDate, float salary)
        {
            var contract = CreateContractObject();
            contract.EmployeeId = employeeId;
            contract.StartDate = startDate;
            var nullDate = new DateTime(0001, 01, 01, 00, 00, 00);
            if (endDate == nullDate)
            {
                contract.EndDate = null;
            }
            else
            {
                contract.EndDate = endDate;
            }
            contract.Salary = salary;

            await _contractsRepository.AddAsync(contract);
            await _contractsRepository.SaveChangesAsync();

            var res = await _employeeService.UpdateEmployeeActivityStatus(employeeId);
            if (!res.IsSuccess)
            {
                return Result.Error(res.Errors.ToArray());
            }

            return Result.Success();
        }

        public async Task<Result> UpdateContract(int contractId, int employeeId, DateTime startDate, DateTime endDate, float salary)
        {
            var contract = await _contractsRepository.GetByIdAsync(contractId);
            if (contract == null)
            {
                return Result.Error("Contract not found.");
            }
            contract.StartDate = startDate;
            var nullDate = new DateTime(0001, 01, 01, 00, 00, 00);
            if(endDate == nullDate)
            {
                contract.EndDate = null;
            }
            else
            {
                contract.EndDate = endDate;
            }
            contract.Salary = salary;

            await _contractsRepository.UpdateAsync(contract);
            await _contractsRepository.SaveChangesAsync();

            var res = await _employeeService.UpdateEmployeeActivityStatus(employeeId);
            if (!res.IsSuccess)
            {
                return Result.Error(res.Errors.ToArray());
            }
            return Result.Success();
        }

        public async Task<Result> ActivateContract(int contractId)
        {
            var contract = await _contractsRepository.GetByIdAsync(contractId);
            if (contract == null)
            {
                return Result.Error("Contract not found");
            }

            contract.StartDate = DateTime.Now;

            await _contractsRepository.UpdateAsync(contract);
            await _contractsRepository.SaveChangesAsync();

            var res = await _employeeService.UpdateEmployeeActivityStatus(contract.EmployeeId);
            if (!res.IsSuccess)
            {
                return Result.Error(res.Errors.ToArray());
            }
            return Result.Success();

        }


        private EmployeeContract CreateContractObject()
        {
            try
            {
                return Activator.CreateInstance<EmployeeContract>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(EmployeeContract)}'.");
            }
        }
    }
}
