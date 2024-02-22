using ApplicationCore.Entities.OrderAggregate;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications.Employee
{
    public class FindOrderByUserName : SingleResultSpecification<Order>
    {
        public FindOrderByUserName(string UserName)
        {
            Query.Where(x => x.UserName == UserName).AsSplitQuery();
        }
    }
}
