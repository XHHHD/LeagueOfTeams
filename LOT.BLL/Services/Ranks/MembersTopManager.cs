using LOT.BLL.Models.Members;

namespace LOT.BLL.Services.Ranks
{
    internal class MembersTopManager
    {
        public static List<MemberModel> GetMembersTop() => new List<MemberModel>();
        public static MemberModel GetCurrentMember(int memberID) => null;
        /// <summary>
        /// Check, did the member name is already taked someone.
        /// </summary>
        /// <param name="checkedMemberName"></param>
        /// <returns>Return True if name is free to use and False if name is already used.</returns>
        public static bool IsThisMemberNameFree(string checkedMemberName) => true;
    }
}
