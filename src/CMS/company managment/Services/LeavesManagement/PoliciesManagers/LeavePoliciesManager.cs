using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.PolicyHandlers;
using company_managment.Services.LeavesManagement.Requests;


namespace company_managment.Services.LeavesManagement.PoliciesManagers;

public  abstract class LeavePoliciesManager
{
    public PolicyHandler Handler { get; set; }

    protected LeavePoliciesManager(PolicyHandler handler)
    {
        Handler = handler;
    }

    public RequestMessage HandleRequest(Request request, Employee employee)
    { 
        return Handler.Handle(request, employee);
    }

}
