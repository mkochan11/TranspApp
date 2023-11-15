using ApplicationCore.Entities.EmployeeAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications.Employee;


public class EmployeeActivityFind : SingleResultSpecification<EmployeeActivity>
{
    public EmployeeActivityFind(int employeeId)
    {
        Query.Where(x => x.EmployeeId == employeeId).AsSplitQuery();
    }
}
