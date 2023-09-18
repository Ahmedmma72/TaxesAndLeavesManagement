using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company_managment.Services.LeavesManagement.PolicyHandlers
{
    public class StartDateIsNotDuringALeave : PolicyHandler
    {
        public override RequestMessage Handle(Request request, Employee employee)
        {
            //start date is not during a leave
            if (employee.LeavesHistories.Any(lh => lh.StartDate <= request.StartDate && lh.StartDate.AddDays(lh.Duration-1) >= request.StartDate))
            {
                return new RequestMessage("Start date is during a leave");
            }
            return HandleNext(request, employee);
        }
    }
}
