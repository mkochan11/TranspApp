using ApplicationCore.Entities.EmployeeAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications.Employee;

public class EmployeeContractFind : SingleResultSpecification<EmployeeContract>
{
    public EmployeeContractFind(int employeeId)
    {
        Query.Where(x => x.EmployeeId == employeeId);
    }
}
