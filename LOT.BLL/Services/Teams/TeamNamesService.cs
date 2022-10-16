using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public class TeamsNamesService
    {
        TeamRepository repository;

        public TeamsNamesService()
        {
            repository = new();
        }

        public bool IsThisNamespaceFree(string name) => repository.IsThisNamespaceFree(name);

        public bool IsThisShortNameFree(string shortName) => repository.IsThisShortNameFree(shortName);

        public string GetNewTeamName()
        {
            throw new NotImplementedException();
        }

        public string GetNewShortName(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
