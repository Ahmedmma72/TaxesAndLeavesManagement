

namespace company_managment.Services.LeavesManagement.Requests;

public class Request
{
    public string LeaveType { get; set; }
    public DateOnly StartDate { get; set; }
    public int Duration { get; set; }

    public Request(string leaveType, DateOnly startDate, int duration)
    {
        LeaveType = leaveType;
        StartDate = startDate;
        Duration = duration;
    }
}
