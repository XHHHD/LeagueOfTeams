using LeagueOfTeamsBusinessLogic.Interfaces;

namespace LeagueOfTeamsBusinessLogic.Models.Members
{
    internal class Member : IMember
    {
        /// <summary>
        /// This date will be used for enhancing afk non-played members.
        /// Members, who was generated once, will compete whith player.
        /// </summary>
        private readonly int _id;
        private readonly string _memberNick;
        private byte _memberAge;
        private int _memberEnergy = 100;
        private int _memberMaxEnergy = 100;
        private uint _memberMainExpiriance = 0;
        private byte _memberFreeMainSkillPoints = 0;
        private List<MemberPosition> _memberPositions;
        private MemberPosition _currentlyMemberMainPosition;
        private List<MemberTrail> _memberTrailsList;
        public readonly DateTime memberCreationDate;
        readonly Random random = new();

        public int Id { get => _id; }
        public string MemberNick { get => _memberNick; }
        public byte MemberAge { get => _memberAge; }
        public int MemberPower { get => _currentlyMemberMainPosition.PositionPower; }
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
        public List<MemberPosition> MemberPositions { get => _memberPositions; }
        public MemberPosition CurrentMemberMainPosition { get => _currentlyMemberMainPosition; }
        public List<MemberTrail> MemberTrails { get => _memberTrailsList; }


        public Member(uint playerLevel)
        {
            memberCreationDate = DateTime.UtcNow;
            _memberNick = MemberNickGenerator.MakeNewMemberNick();

            //Age must be between 14 and 30 yers. Because members, who more then 30 years old whil luse they characteristics.
            //Mmebers, who more then 35, will ask player keep them out. And players 40 years old will out team instantly.
            _memberAge = (byte)(14 + random.Next(0,2) + playerLevel/3);
            if (_memberAge > 30) _memberAge = 30;
            
            //Making main position for the member. First main position always must be.
            MemberPosition firstMemberPosition = new(playerLevel);
            _currentlyMemberMainPosition = firstMemberPosition;
            _memberPositions.Add(firstMemberPosition);

            //There must be 50% chanse to get member with two positions.
            if (random.Next(0, 1) == 1)
            {
                MemberPosition secondaryMemberPosition = new(firstMemberPosition.PositionName, playerLevel, true);
                _memberPositions.Add(secondaryMemberPosition);
            }

            MemberTrail memberTrails = new();
        }

        /// <summary>
        /// Method, that will swich player main position between positions he already learned.
        /// </summary>
        /// <param name="positionName"></param>
        internal void SetMemberMainPosition(string positionName)
        {
            if (_currentlyMemberMainPosition.PositionName != positionName)
            {
                foreach (MemberPosition position in MemberPositions)
                {
                    if (position.PositionName == positionName)
                    {
                        _currentlyMemberMainPosition = position;
                        break;
                    }
                }
            }
        }
        internal string AddMemberPosition(string addPositionName, uint playerLevel)
        {
            foreach (MemberPosition position in MemberPositions)
            {
                if (position.PositionName == addPositionName)
                {
                    return "Error! This member is already can play this position!";
                }
            }
            MemberPositions.Add( _currentlyMemberMainPosition = new MemberPosition(addPositionName, playerLevel));
            return "Done!";
        }
    }
}
