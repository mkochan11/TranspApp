using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEmployeeService
    {
        Task<Result> UpdateEmployeeActivityStatus(int employeeId);
        Task<Result> AddContractToEmployee(int employeeId, int contractId);
    }
}
