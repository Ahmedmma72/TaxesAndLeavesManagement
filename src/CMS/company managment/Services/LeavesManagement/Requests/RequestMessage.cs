namespace company_managment.Services.LeavesManagement.Requests;

public class RequestMessage
{
    public string Message { get; set; }
    public bool IsApproved { get; set; }

    public RequestMessage(string message, bool isApproved = false)
    {
        Message = message;
        IsApproved = isApproved;
    }
}
