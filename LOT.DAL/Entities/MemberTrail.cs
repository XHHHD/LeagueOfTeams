namespace LOT.DAL.Entities
{
    public class MemberTrail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Member> Member { get; set; }
    }
}
