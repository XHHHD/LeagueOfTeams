using LeagueOfTeamsBusinessLogic.Models.Members;

namespace LeagueOfTeamsBusinessLogic.Models.Top
{
    internal class MembersTopManager
    {
        public static List<Member> GetMembersTop() => new List<Member>();
        public static Member GetCurrentMember(int memberID) => null;
        /// <summary>
        /// Check, did the member name is already taked someone.
        /// </summary>
        /// <param name="checkedMemberName"></param>
        /// <returns>Return False if name is used and True if name is free to use.</returns>
        public static bool IsThisMemberNameFree(string checkedMemberName) => true;
    }
}
