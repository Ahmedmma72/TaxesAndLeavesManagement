namespace company_managment.Services.LeavesManagement.Leaves;

public static class LeavesFactory
{
    public static Dictionary<int, string> TypesOfLeavesMap()
    {
        return new Dictionary<int, string>()
        {
            {1, typeof(SickLeave).Name},
            {2, typeof(CasualLeave).Name},
        };
    }
    public static List<Leave> getListOfLeaves()
    {
        return new List<Leave>()
        {
            new SickLeave(),
            new CasualLeave(),
        };
    }

}
