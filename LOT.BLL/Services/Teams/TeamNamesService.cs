using LOT.BLL.Models.Teams;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public class TeamsNamesService
    {
        Random random;
        TeamRepository repository;

        public TeamsNamesService()
        {
            random = new();
            repository = new();
        }

        public bool IsThisNamespaceFree(string name) => repository.IsThisNamespaceFree(name);

        public bool IsThisShortNameFree(string shortName) => repository.IsThisShortNameFree(shortName);

        public string GetNewTeamName()
        {
            var name = DefaultTeamNamesSource.FirstNamesList[random.Next(0, DefaultTeamNamesSource.FirstNamesList.Count)];
            name += " ";
            name += DefaultTeamNamesSource.SecondNamesList[random.Next(0, DefaultTeamNamesSource.SecondNamesList.Count)];
            return name;
        }

        public string GetNewShortName(string teamName)
        {
            return teamName.Remove(4).ToUpper();
        }
    }
}
