using LOT.BLL.Models.Members;
using LOT.BLL.Services.Ranks;
using LOT.BLL.Models.DTO;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Trails;
using LOT.DAL.Interfaces;
using LOT.BLL.Models.Ranks;

namespace LOT.BLL.Models.Teams
{
    public class TeamModel : ITeam
    {
        private int _id;
        private string _name = "";
        private string _shortName = "";
        private string _description = "There are no description here.";
        private uint _expiriance = 0;
        private int _energy = 0;
        private int _power = 0;
        private int _health = 0;
        private int _teamplay = 0;
        private int _rankPoints = 0;
        private string _img = "/Resources/Default/icons8-ос-free-bsd-100-white.png";

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ShortName { get => _shortName; set => _shortName = value; }
        public string DisplayName
        {
            get => _shortName;
            set
            {
                if (value == null) _shortName = _name;
                else _shortName = value;
            }
        }
        public string? Description
        {
            get => _description;
            set
            {
                if (value != null) _description = value;
            }
        }
        public UserModel? User { get; set; }
        public TeamTrailModel? TeamTrail { get; set; }
        public TeamRankModel TeamRank { get; set; }
        public List<MemberModel> Members { get; set; }
        public uint Expiriance { get => _expiriance % 1000; set => _expiriance = value; }
        public uint Level { get => _expiriance/1000 + 1; }
        public int Energy { get => _energy; set => _energy = value; }
        public int Power { get => _power; set => _power = value; }
        public int Health { get => _health; set => _health = value;  }
        public int Teamplay { get => _teamplay; set => _teamplay = value; }
        public int RankPoints { get => _rankPoints; set => _rankPoints = value; }
        public string Image { get => _img; set => _img = value; }
        public int TeamRankId { get; set; }
        public int TeamTrailId { get; set; }
        public int? UserId { get; set; }

        public TeamModel()
        {

        }
        // MOVE REGISTRATION LOGIC TO SERVICE!
        public TeamModel(TeamRegistrationDTO newTeam)
        {
            Members = new List<MemberModel>();
            if (newTeam.Name != null && TeamsTopManager.IsThisNamespaceFree(newTeam.Name)) _name = newTeam.Name;
            else throw new TeamRegistrationException("Set new team name.");
            string teamShortName;
            if (newTeam.ShortName == null)
            {
                teamShortName = _name.Remove(2, _name.Length - 1).ToUpper();
                if (TeamsTopManager.IsThisNamespaceFree(teamShortName)) _name = teamShortName;
                else throw new TeamRegistrationException("Auto generated TeamShortName is already taken.");
            }
            else
            {
                if (TeamsTopManager.IsThisNamespaceFree(newTeam.ShortName)) _name = newTeam.ShortName.ToUpper();
                else throw new TeamRegistrationException("TeamShortName provided by User is already taken.");
            }
            if (newTeam.Description != null) _description = newTeam.Description;

        }
        public void AddExpiriance(uint addedValue) => _expiriance += addedValue;
    }
}
