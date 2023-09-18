using company_managment.Services.LeavesManagement.PolicyHandlers;


namespace company_managment.Services.LeavesManagement.PoliciesManagers;

public static class LeavesPoliciesManagerFactory
{
    public static List<LeavePoliciesManager> GetLeavePolicies()
    {
        PolicyHandler sickLeavePoliciesHandlers = new StartDateIsNotDuringALeave();
        sickLeavePoliciesHandlers.SetNext(new EnoughBalancePolicy()).SetNext(new SameWeekPolicy());

        PolicyHandler casualLeavePoliciesHandlers = new StartDateIsNotDuringALeave();
        casualLeavePoliciesHandlers.SetNext(new EnoughBalancePolicy()).SetNext(new SameMonthPolicy());


        
        List<LeavePoliciesManager> leavePolicies = new List<LeavePoliciesManager>
        {
            new SickLeavePoliciesManager(
                sickLeavePoliciesHandlers
                    ),
            new CasualLeavePoliciesManager(
                    casualLeavePoliciesHandlers
                    )
        };
        return leavePolicies;

    }
}
