using LOT.BLL.Models.Members;
using LOT.BLL.Models.DTO;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Trails;
using LOT.DAL.Interfaces;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Services.Teams;

namespace LOT.BLL.Models.Teams
{
    public class TeamModel : ITeam
    {
        private int _id;
        private string _name = "";
        private string _shortName = "";
        private string _description = "This team has no any description.";
        private uint _expiriance = 0;
        private int _energy = 0;
        private int _maxEnergy = 0;
        private int _health = 0;
        private int _power = 0;
        private int _teamplay = 0;
        private int _rankPoints = 0;
        private string _img = "/Resources/Default/icons8-ос-free-bsd-100-white.png";

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ShortName
        {
            get => _shortName;
            set
            {
                if (value == null)
                    _shortName = _name.ToUpper().Remove(2);
                else if (value.Length >= 4)
                    _shortName = value.ToUpper().Remove(2);
                else
                    _shortName = value.ToUpper();
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (value != null) _description = value;
            }
        }
        public UserModel? User { get; set; }
        public TeamTrailModel? TeamTrail { get; set; }
        public TeamRankModel? TeamRank { get; set; }
        public List<MemberModel> Members { get; set; }
        public uint Expiriance { get => _expiriance % 1000; set => _expiriance = value; }
        public uint Level { get => _expiriance/1000 + 1; }
        public int Energy
        {
            get => _energy;
            set
            {
                if(value >= _maxEnergy)
                    _energy = _maxEnergy;
                else
                    _energy = value;
            }
        }
        public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }
        public int Health { get => _health; set => _health = value;  }
        public int Power { get => _power; set => _power = value; }
        public int Teamplay { get => _teamplay; set => _teamplay = value; }
        public int RankPoints { get => _rankPoints; set => _rankPoints = value; }
        public string Image { get => _img; set => _img = value; }
        public int? TeamRankId { get; set; }
        public int? TeamTrailId { get; set; }
        public int? UserId { get; set; }

        public TeamModel()
        {

        }
        // MOVE REGISTRATION LOGIC TO SERVICE!
        public TeamModel(TeamRegistrationDTO newTeam)
        {
            Members = new List<MemberModel>();
            if (newTeam.Name != null && TeamsNamesService.IsThisNamespaceFree(newTeam.Name)) _name = newTeam.Name;
            else throw new TeamServicesException("Set new team name.");
            string teamShortName;
            if (newTeam.ShortName == null)
            {
                teamShortName = _name.Remove(2, _name.Length - 1).ToUpper();
                if (TeamsNamesService.IsThisNamespaceFree(teamShortName)) _name = teamShortName;
                else throw new TeamServicesException("Auto generated TeamShortName is already taken.");
            }
            else
            {
                if (TeamsNamesService.IsThisNamespaceFree(newTeam.ShortName)) _name = newTeam.ShortName.ToUpper();
                else throw new TeamServicesException("TeamShortName provided by User is already taken.");
            }
            if (newTeam.Description != null) _description = newTeam.Description;

        }
        public void AddExpiriance(uint addedValue) => _expiriance += addedValue;
    }
}
