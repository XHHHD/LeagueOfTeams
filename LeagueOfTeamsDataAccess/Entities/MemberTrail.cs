namespace LeagueOfTeamsDataAccess.Entities
{
    public class MemberTrail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
