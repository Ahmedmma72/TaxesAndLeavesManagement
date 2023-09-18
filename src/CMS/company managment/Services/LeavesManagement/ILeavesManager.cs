using company_managment.Models.Employees;
using company_managment.Services.LeavesManagement.Requests;

namespace company_managment.Services.LeavesManagement
{
    public interface ILeavesManager
    {
        RequestMessage HandleRequest(Request request, Employee employee);
    }
}