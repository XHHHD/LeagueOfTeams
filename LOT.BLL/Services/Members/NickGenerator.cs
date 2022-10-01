using LOT.BLL.Services.Ranks;
using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Members
{
    internal class NickGenerator
    {
        static Random random = new();
        internal static string GenerateNewMemberNick()
        {
            HashSet<int> usedNamesID = new HashSet<int>();
            foreach (MemberModel member in MembersTopManager.GetMembersTop())
            {
                if (DefaultNicksSource.nicksList.IndexOf(member.Name) != -1)
                    usedNamesID.Add(DefaultNicksSource.nicksList.IndexOf(member.Name));
            }
            var notUsedInexes = Enumerable.Range(0, DefaultNicksSource.nicksList.Count - 1)
                .Where(i => !usedNamesID.Contains(i));
            int randomNameIndexForNotUsedInexes = random.Next(0, 100 - usedNamesID.Count);
            return DefaultNicksSource.nicksList[notUsedInexes.ElementAt(randomNameIndexForNotUsedInexes)];
        }
    }
}
