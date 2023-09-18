
using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.Services.LeavesManagement.PolicyHandlers;

public abstract class PolicyHandler
{
    private PolicyHandler? _nextHandler;
    public PolicyHandler SetNext(PolicyHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }
    public abstract RequestMessage Handle(Request request, Employee employee);
    protected virtual RequestMessage HandleNext(Request request, Employee employee)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(request,employee);
        }
        return new RequestMessage("Request is approved",true);
    }

}
