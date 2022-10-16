using LOT.BLL.Models.Positions;
using LOT.BLL.Models.Teams;
using LOT.BLL.Services.Members;
using LOT.BLL.Enums;

namespace LOT.BLL.Models.DTO
{
    public class MemberRegistrationDTO
    {
        private Random random = new();
        public readonly DateTime _creationDate;
        private DateTime _lastChanges;
        private string _img = "/Resources/Default/icons8-ос-free-bsd-100-black.png";
        private byte _age;
        private int _energy = 100;
        private int _maxEnergy = 100;
        private uint _expiriance = 0;
        private byte _skillPoints = 0;

        public DateTime CreationDate => _creationDate;
        public DateTime LastChanges => _lastChanges;
        public string Nick { get; set; }
        public string Image => _img;
        public byte Age => _age;
        public int Power => Positions[0].Power;
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
        public uint Expiriance { get => _expiriance; }
        public byte SkillPoints { get => _skillPoints; set => _skillPoints = value; }
        public List<PositionModel> Positions { get; set; }
        public TeamModel? Team { get; set; }

        //public MemberRegistrationDTO(UserModel user, PositionsNames positionName)
        //{
        //    Nick = NickGenerator.GenerateNewNick();
        //    //Age must be between 14 and 30 yers. Because members, who more then 30 years old whil luse they characteristics.
        //    //Mmebers, who more then 35, will ask player keep them out. And players 40 years old will out team instantly.
        //    _age = (byte)(14 + random.Next(0, 2) + user.Level / 3);
        //    if (_age > 30) _age = 30;
        //    //Making main position for the member. First main position always must be.
        //    PositionService.AddPosition(user, Positions, positionName);
        //    //There must be 50% chanse to get member with two positions.
        //    if (random.Next(0, 1) == 1)
        //    {
        //        Array names = Enum.GetValues(typeof(PositionsNames));
        //        PositionsNames name = (PositionsNames)names.GetValue(random.Next(names.Length));
        //        PositionService.AddPosition(user, Positions, name);
        //    }
        //    _maxEnergy = 100 + random.Next(-5, 5);
        //    _energy = _maxEnergy;
        //}
    }
}
