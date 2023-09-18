using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;


namespace company_managment.Services.LeavesManagement.PolicyHandlers;

public class SameWeekPolicy : PolicyHandler
{
    public override RequestMessage Handle(Request request, Employee employee)
    {
        // Look through the leaves histroy and reject if there is a leave in the same week

        var sickLeaves = employee.LeavesHistories.Where(l => l.LeaveType == request.LeaveType).ToList();

        foreach (var leave in sickLeaves)
        {
            if(AreInTheSameWeek(leave.StartDate,request.StartDate) || AreInTheSameWeek(leave.StartDate.AddDays(leave.Duration-1),request.StartDate.AddDays(request.Duration)))
                return new RequestMessage("You can't request a leave in the same week as another leave");
         }
        return HandleNext(request, employee);
    }
    private bool AreInTheSameWeek(DateOnly date1, DateOnly date2)
    {
        var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
        var d1 = date1.ToDateTime(TimeOnly.MinValue);
        var d2 = date2.ToDateTime(TimeOnly.MinValue);
        return cal.GetWeekOfYear(d1, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday) == cal.GetWeekOfYear(d2, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday); 
    }
}
