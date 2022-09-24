﻿namespace LeagueOfTeamsBusinessLogic.Models.Members
{
    public class MemberTrail
    {
        //There will be different trails, which can be added to members
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Member> Members { get; set; }
    }
}
