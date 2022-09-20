using LeagueOfTeamsBusinessLogic.Interfaces;
using LeagueOfTeamsBusinessLogic.Models.Teams;

namespace LeagueOfTeamsBusinessLogic.Models.Members
{
    public class Member : IMember
    {
        /// <summary>
        /// This date will be used for enhancing afk non-played members.
        /// Members, who was generated once, will compete whith player.
        /// </summary>
        public readonly DateTime memberCreationDate;
        private readonly int _id;
        private readonly string _memberNick;
        private byte _memberAge;
        private int _memberEnergy = 100;
        private int _memberMaxEnergy = 100;
        private uint _memberMainExpiriance = 0;
        private byte _memberFreeMainSkillPoints = 0;
        private List<MemberTrail> _trails;
        private DateTime _lastUpdateTime;
        readonly Random random = new();

        public int Id { get => _id; }
        public string MemberNick { get => _memberNick; }
        public byte MemberAge { get => _memberAge; }
        //public int MemberPower { get => _currentlyMemberMainPositionId.PositionPower; }
        public int MemberEnergy
        {
            get => _memberEnergy;
            set
            {
                if (value <= MemberMaxEnergy) _memberEnergy = value;
                else _memberEnergy = MemberMaxEnergy;
            }
        }
        public int MemberMaxEnergy { get => _memberMaxEnergy; set => _memberMaxEnergy = value; }
        public uint MemberMainExpiriance { get => _memberMainExpiriance; }
        public byte MemberFreeMainSkillPoints { get => _memberFreeMainSkillPoints; set => _memberFreeMainSkillPoints = value; }
        int TeamId { get; set; }
        Team Team { get; set; }
        public List<Position> Positions { get; set; }
        public Position MainPosition { get; set; }
        public List<MemberTrail> MemberTrailsId { get; set; }


        public Member(uint playerLevel)
        {
            memberCreationDate = DateTime.UtcNow;
            _lastUpdateTime = DateTime.UtcNow;
            _memberNick = MemberNickGenerator.GenerateNewMemberNick();

            //Age must be between 14 and 30 yers. Because members, who more then 30 years old whil luse they characteristics.
            //Mmebers, who more then 35, will ask player keep them out. And players 40 years old will out team instantly.
            _memberAge = (byte)(14 + random.Next(0,2) + playerLevel/3);
            if (_memberAge > 30) _memberAge = 30;
            
            //Making main position for the member. First main position always must be.
            Position firstMemberPosition = new(playerLevel);
            MainPosition = firstMemberPosition;
            Positions.Add(firstMemberPosition);

            //There must be 50% chanse to get member with two positions.
            if (random.Next(0, 1) == 1)
            {
                Position secondaryMemberPosition = new(firstMemberPosition.PositionName, playerLevel, true);
                Positions.Add(secondaryMemberPosition);
            }

            MemberTrail memberTrails = new();
        }

        /// <summary>
        /// Method, that will swich player main position between positions he already learned.
        /// </summary>
        /// <param name="positionName"></param>
        internal void SetMemberMainPosition(string positionName)
        {
            if (MainPosition.PositionName != positionName)
            {
                foreach (Position position in Positions)
                {
                    if (position.PositionName == positionName)
                    {
                        MainPosition = position;
                        break;
                    }
                }
            }
        }
        internal string AddMemberPosition(string addPositionName, uint playerLevel)
        {
            foreach (Position position in Positions)
            {
                if (position.PositionName == addPositionName)
                {
                    return "Error! This member is already can play this position!";
                }
            }
            Positions.Add(MainPosition = new Position(addPositionName, playerLevel));
            return "Done!";
        }
    }
}
