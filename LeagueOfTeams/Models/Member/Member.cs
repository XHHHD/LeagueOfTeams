using System;
using LeagueOfTeamsModel.Interfaces;

namespace LeagueOfTeamsModel.Models.Member
{
    internal class Member : IMember
    {
        //This date will be used for enhancing afk non-played members.
        //Members, who was generated once, will compete whith player.
        public readonly DateTime memberCreationDate;
        readonly Random random = new();
        private readonly uint _memberID;
        private readonly string _memberName;
        private MemberPosition[] _memberPositions;
        private byte _memberAge;
        private int _memberEnergy = 100;
        private int _memberMaxEnergy = 100;
        private uint _memberMainExpiriance = 0;
        private byte _memberFreeMainSkillPoints = 0;
        private MemberTrail[]? _memberTrailsList;

        public uint MemberID { get => _memberID; }
        public string MemberName { get => _memberName; }
        public MemberPosition[] MemberPositions { get; }
        public byte MemberAge { get => _memberAge; }
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
        public uint MemberMainExpiriance { get => _memberMainExpiriance; set => _memberMainExpiriance = value; }
        public byte MemberFreeMainSkillPoints { get => _memberFreeMainSkillPoints; set => _memberFreeMainSkillPoints = value; }
        public MemberTrail[] MemberTrails { get => _memberTrailsList; }


        public Member(uint playerLevel)
        {
            memberCreationDate = DateTime.UtcNow;
            _memberID;
            _memberName = MemberNameGenerator.MakeNewMemberName();

            //Making main position for member. First main position always must be.
            MemberPosition firstMembemPosition = new(playerLevel);
            _memberPositions = new[] { firstMembemPosition };

            //There must be 50% chanse to get member with two positions.
            if (random.Next(0, 1) == 1)
            {
                MemberPosition secondaryMemberPosition = new(firstMembemPosition.PositionName, playerLevel, true);
                _memberPositions.AsMemory<> = secondaryMemberPosition;
            }

            //Age must be from 14 to 30 yers. Because members, who more then 30 years old whil luse they characteristics.
            //Mmebers, who more then 35, will ask player keep them out. And players 40 years old will out team instantly.
            _memberAge = (byte)(14 + random.Next(0,4) + playerLevel/3);
            if (_memberAge > 30) _memberAge = 30;
        }
    }
}
