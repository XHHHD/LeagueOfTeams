using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Members
{
    public static class MemberGenerator
    {
        private static Random random = new();
        public static MemberModel GenerateNewMember(uint exp)
        {
            uint level = exp / 1000;
            MemberModel member = new()
            {
                CreationDate = DateTime.Now,
                LastChanges = DateTime.Now,
                Age = (byte)(14 + random.Next(0, 2) + level / 3),
                Energy = 100,
                MaxEnergy = 100 + random.Next(-5, (int)level),
                Expiriance = 0,
                SkillPoints = 0,
                RankPoints = 0
            };
            member.Id = MemberService.GetFreeMemberId();
            member.Name = NickGenerator.GenerateNewNick();
            if (member.Age > 30)
                member.Age = 30;
            member.Energy = member.MaxEnergy;
            member.Expiriance = exp + (uint)random.Next(0, 2780);
            if((int)(member.Expiriance - exp) - 2000 < 0)
                member.Expiriance = 0;
            return member;
        }
    }
}
