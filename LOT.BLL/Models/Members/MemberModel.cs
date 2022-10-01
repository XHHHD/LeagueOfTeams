using LOT.BLL.Models.DTO;
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
        private readonly int _id;
        private string _name;
        private string _img;
        private byte _age;
        private int _power;
        private int _energy;
        private int _maxEnergy;
        private uint _expiriance;
        private byte _skillPoints;
        private int _rankPoints;

        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }
        public DateTime LastChanges { get => _lastChanges; set => _lastChanges = value; }
        public int Id => _id;
        public string Name { get => _name; set => _name = value; }
        public string Image { get => _img; set => _img = value; }
        public byte Age { get => _age; set => _age = value; }
        public int Power => _power;
        public int Energy
        {
            get => _energy;
            set
            {
                if (value <= MaxEnergy) _energy = value;
                else _energy = MaxEnergy;
            }
        }
        public int MaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }
        public uint Expiriance { get => _expiriance; set => _expiriance = value; }
        public byte SkillPoints { get => _skillPoints; set => _skillPoints = value; }
        public int RankPoints { get => _rankPoints; set => _rankPoints = value; }
        //PROXY KEY's
        public int? TeamId { get; set; }
        public int? MemberRankId { get; set; }
        public int? MemberTrailId { get; set; }
        TeamModel? Team { get; set; }
        public List<PositionModel> Positions { get; set; }
        public List<MemberTrailModel>? Trails { get; set; }


        public MemberModel(UserModel user, MemberRegistrationDTO dTO)
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
        }
    }
}
