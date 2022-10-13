using LOT.BLL.Models.Members;

namespace LOT.BLL.Models.Ranks
{
    public class MemberRankModel
    {
        public static readonly int maxMembersCount = 40;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MemberModel> Members { get; set; }
    }
}
