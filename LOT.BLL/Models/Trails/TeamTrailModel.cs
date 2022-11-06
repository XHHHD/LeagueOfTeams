using LOT.BLL.Models.Teams;

namespace LOT.BLL.Models.Trails
{
    public class TeamTrailModel
    {
        //There will be trails of player, wich can be added to the team.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public TeamModel Team { get; set; }
    }
}
