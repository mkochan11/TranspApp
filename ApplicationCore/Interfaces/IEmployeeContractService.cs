using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities.EmployeeAggregate;
using Ardalis.Result;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeeContractService
    {
        Task<Result> TerminateContract(int contractId);
        Task<Result> RenewContract(int contractId);
        Task<Result> DeleteContract(int contractId);
        Task<Result> CreateContract(int employeeId, DateTime startDate, DateTime endDate, float salary);
        Task<Result> UpdateContract(int contractId, int employeeId, DateTime startDate, DateTime endDate, float salary);
        Task<Result> ActivateContract(int contractId);
    }
}
