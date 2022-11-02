using LOT.BLL.Enums;
using LOT.BLL.Models.DTO;
using LOT.BLL.Models.Positions;
using LOT.BLL.Models.Teams;
using LOT.BLL.Models.Trails;
using LOT.DAL.Interfaces;

namespace LOT.BLL.Models.Members
{
    public class MemberModel : IMember
    {
        /// <summary>
        /// This date will be used for enhancing afk non-played members.
        /// Members, who was generated once, will compete whith player.
        /// </summary>
        public DateTime _creationDate;
        private DateTime _lastChanges;
        private int _id;
        private string _name;
        private string _img;
        private byte _age;
        private int _power;
        private int _energy;
        private int _maxEnergy;
        private int _mentalPower;
        private int _mentalResistance;
        private int _teamplay;
        private uint _expiriance;
        private byte _skillPoints;
        private int _rankPoints;

        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }
        public DateTime LastChanges { get => _lastChanges; set => _lastChanges = value; }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Image { get => _img; set => _img = value; }
        public byte Age { get => _age; set => _age = value; }
        public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }
        public int Energy
        {
            get => _energy;
            set
            {
                if (value <= MaxEnergy) _energy = value;
                else _energy = MaxEnergy;
            }
        }
        public int Power
        {
            get
            {
                if(Positions == null || Positions.Count == 0)
                    return _power;
                else
                    return _power + Positions[0].Power;
            }
            set => _power = value;
        }
        public int MentalPower { get => _mentalPower; set => _mentalPower = value; }
        public int MentalResistance { get => _mentalResistance; set => _mentalResistance = value; }
        public int Teamplay { get => _teamplay; set => _teamplay = value; }
        public uint Expiriance { get => _expiriance % 1000; set => _expiriance = value; }
        public uint Level { get => _expiriance / 1000; }
        public byte SkillPoints { get => _skillPoints; set => _skillPoints = value; }
        public int RankPoints { get => _rankPoints; set => _rankPoints = value; }
        
        //PROXY KEY's
        public int? TeamId { get; set; }
        public int? MemberRankId { get; set; }
        public int? MemberTrailId { get; set; }
        TeamModel? Team { get; set; }
        public List<PositionModel> Positions { get; set; }
        public List<MemberTrailModel> Trails { get; set; }


        public MemberModel()
        {

        }
        public MemberModel(MemberRegistrationDTO dTO)
        {
            _creationDate = DateTime.UtcNow;
            _lastChanges = DateTime.UtcNow;
            _name = dTO.Nick;
            _img = dTO.Image;
            _age = dTO.Age;
            _power = dTO.Power;
            _energy = dTO.Energy;
            _maxEnergy = dTO.MaxEnergy;
            _expiriance = dTO.Expiriance;
            _skillPoints = dTO.SkillPoints;
            Positions = dTO.Positions;
            Trails = new();
        }
        public void AddExpiriance(uint exp)
        {
            uint levelWas = Level;
            _expiriance += exp;
            if (levelWas < Level)
                LevelUp(Level - levelWas);
        }
        private void LevelUp(uint levelDifference)
        {
            _maxEnergy += (int)levelDifference*5;
            _energy = _maxEnergy;
            _power += (int)levelDifference;
            _skillPoints += (byte)levelDifference;
        }
        public void AddStat(StatsUp stat)
        {
            if (_skillPoints < 0)
            {
                switch (stat)
                {
                    case StatsUp.Power:
                        {
                            _power++;
                            break;
                        }
                    case StatsUp.MaxEnergy:
                        {
                            _maxEnergy++;
                            break;
                        }
                    case StatsUp.MenthalPower:
                        {
                            _mentalPower++;
                            break;
                        }
                    case StatsUp.MenthalHealth:
                        {
                            _mentalResistance++;
                            break;
                        }
                    case StatsUp.Teamplay:
                        {
                            _teamplay++;
                            break;
                        }
                    default:
                        {
                            Positions[0].AddStats(stat);
                            break;
                        }
                }
            }
        }
    }
}
