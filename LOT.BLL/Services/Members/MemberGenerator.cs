using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Members
{
    public static class MemberGenerator
    {
        private static Random random = new();

        /// <summary>
        /// Make new member.
        /// </summary>
        /// <param name="exp">User expiriance.</param>
        /// <returns>New Member.</returns>
        public static MemberModel GenerateNewMember(uint exp)
        {
            MemberModel member = GenerateEmptyMember();
            uint level = exp / 1000;
            member.Id = MemberService.GetFreeMemberId();
            member.Name = NickGenerator.GenerateNewNick();
            member.Age = (byte)(14 + random.Next(0, 2) + level / 3);
            if (member.Age > 30)
                member.Age = 30;
            member.MaxEnergy = 100 + random.Next(-5, (int)level);
            member.Energy = member.MaxEnergy;
            member.Expiriance = exp + (uint)random.Next(0, 2780);
            if((int)(member.Expiriance - exp) - 2000 < 0)
                member.Expiriance = 0;
            return member;
        }

        /// <summary>
        /// Generate empty default member without using any parameters.
        /// </summary>
        /// <returns></returns>
        public static MemberModel GenerateEmptyMember() => new()
        {
            CreationDate = DateTime.Now,
            LastChanges = DateTime.Now,
            Age = 14,
            Energy = 100,
            MaxEnergy = 100,
            Expiriance = 0,
            SkillPoints = 0,
            RankPoints = 0
        };
    }
}
