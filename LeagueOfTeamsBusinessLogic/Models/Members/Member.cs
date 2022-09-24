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
        public readonly DateTime _creationDate;
        private DateTime _lastChanges;
        private readonly int _id;
        private readonly string _nick;
        private byte _age;
        private int _energy = 100;
        private int _maxEnergy = 100;
        private uint _expiriance = 0;
        private byte _freeMainSkillPoints = 0;
        private List<MemberTrail> _trails;
        int _teamId;

        public DateTime CreationDate => _creationDate;
        public DateTime LastChanges => _lastChanges;
        public int Id { get => _id; }
        public string Nick => _nick;
        public byte Age => _age;
        //public int Power { get => _currentlyMemberMainPositionId.PositionPower; }
        public int Energy
        {
            get => _energy;
            set
            {
                if (value <= MemberMaxEnergy) _energy = value;
                else _energy = MemberMaxEnergy;
            }
        }
        public int MemberMaxEnergy { get => _maxEnergy; set => _maxEnergy = value; }
        public uint MemberMainExpiriance { get => _expiriance; }
        public byte MemberFreeMainSkillPoints { get => _freeMainSkillPoints; set => _freeMainSkillPoints = value; }
        Team Team
        {
            get => TeamRepository.GetTeam(_teamId);
            set
            {
                _teamId = value.TeamID;
            }
        }
        public List<Position> Positions { get; set; }
        public List<MemberTrail> MemberTrailsId { get; set; }


        public Member(uint playerLevel)
        {
            _creationDate = DateTime.UtcNow;
            _lastChanges = DateTime.UtcNow;
            _nick = MemberNickGenerator.GenerateNewMemberNick();

            //Age must be between 14 and 30 yers. Because members, who more then 30 years old whil luse they characteristics.
            //Mmebers, who more then 35, will ask player keep them out. And players 40 years old will out team instantly.
            _age = (byte)(14 + random.Next(0,2) + playerLevel/3);
            if (_age > 30) _age = 30;
            
            //Making main position for the member. First main position always must be.
            Positions.Add(new Position(playerLevel));

            //There must be 50% chanse to get member with two positions.
            if (random.Next(0, 1) == 1)
            {
                Position secondaryMemberPosition = new(Positions[0].PositionName, playerLevel, true);
                Positions.Add(secondaryMemberPosition);
            }

            MemberTrail memberTrails = new();
        }

        /// <summary>
        /// Method, that will swich player main position between positions he already learned.
        /// </summary>
        /// <param name="positionName"></param>
        internal void ChangeMainPosition(Position newMainPosition)
        {
            if (!Positions[0].Equals(newMainPosition)) Positions.Reverse();
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
            Positions.Add(Positions[0] = new Position(addPositionName, playerLevel));
            return "Done!";
        }
    }
}
