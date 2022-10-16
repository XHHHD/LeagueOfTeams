using LOT.BLL.Exceptions;
using LOT.BLL.Services.Teams;

namespace LOT.BLL.Models.DTO
{
    public class TeamRegistrationDTO
    {
        private TeamsNamesService namesService;
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public TeamRegistrationDTO(string name, string shortName = "", string description = "")
        {
            namesService = new();
            //
            if (name is null || name == "")
                throw new TeamServicesException("New team name is NULL or empty!");
            else
            {
                if (namesService.IsThisNamespaceFree(name))
                    Name = name;
                else
                    throw new TeamServicesException("Team name is already used!");
            }
            //
            if (shortName == "" || shortName is null)
                ShortName = namesService.GetNewShortName(name);
            else
                ShortName = shortName;
            //
            if (description == "" || description is null)
                Description = "This team has no any description.";
            else
                Description = description;
        }
    }
}
