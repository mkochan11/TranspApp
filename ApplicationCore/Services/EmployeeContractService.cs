﻿using ApplicationCore.Entities.EmployeeAggregate;
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
            var oldContract = await GetEmployeeContract(contractId);
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

            var resAddContract = await _employeeService.AddContractToEmployee(newContract.EmployeeId, newContract.Id);
            if (!resAddContract.IsSuccess)
            {
                return Result.Error(resAddContract.Errors.ToArray());
            }

            var resEmpl = await _employeeService.UpdateEmployeeActivityStatus(newContract.EmployeeId);
            if (!resEmpl.IsSuccess) { 
                return Result.Error(resEmpl.Errors.ToArray());
            }
            return Result.Success();
            
        }

        public async Task<Result> TerminateContract(int contractId)
        {
            var contract = await GetEmployeeContract(contractId);
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
            var contract = await GetEmployeeContract(contractId);
            if (contract == null)
            {
                var res = Result.NotFound("Contract not found");
                return res;
            }
            await _contractsRepository.DeleteAsync(contract);
            await _contractsRepository.SaveChangesAsync();
            return Result.Success();
        }

        private async Task<EmployeeContract> GetEmployeeContract(int contractId) 
        { 
            var contract  = await _contractsRepository.GetByIdAsync(contractId);
            return contract;
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

        public Task<Result> CreateContract(EmployeeContract contract)
        {
            throw new NotImplementedException();
        }
    }
}
