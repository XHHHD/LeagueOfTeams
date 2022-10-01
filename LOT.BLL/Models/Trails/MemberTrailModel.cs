using LOT.BLL.Models.Members;

namespace LOT.BLL.Models.Trails
{
    public class MemberTrailModel
    {
        //There will be different trails, which can be added to members
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MemberModel> Members { get; set; }
    }
}
