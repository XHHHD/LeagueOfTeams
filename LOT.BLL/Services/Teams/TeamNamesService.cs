namespace LOT.BLL.Services.Teams
{
    internal static class TeamsNamesService
    {
        internal static bool IsThisNamespaceFree(string name)
        {
            var allTeams = TeamService.GetAllTeams();
            if(allTeams == null)
                return true;
            else if (allTeams.FirstOrDefault(x => x.Name == name) == null)
                return true;
            return false;
        }
    }
}
