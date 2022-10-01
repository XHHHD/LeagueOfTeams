﻿using LOT.DAL.Entities;
using LOT.DAL.Interfaces;

namespace LOT.DAL.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        AppContext _db;
        public MemberRepository()
        {
            string dbConnectionString =
                "Server=(localdb)\\mssqllocaldb;Initial Catalog=MyDB;Integrated Security=True;";
            _db = new AppContext(dbConnectionString);
        }
        /// <summary>
        /// Save in database new member object.
        /// </summary>
        /// <param name="member">Created member</param>
        public void AddMember(Member member)
        {
            _db.Members.Add(member);
            _db.SaveChanges();
        }
        /// <summary>
        /// Delete from database currently member.
        /// </summary>
        /// <param name="member">Member object, that must be deleted.</param>
        public void RemoveMember(Member member)
        {
            _db.Members.Remove(member);
            _db.SaveChanges();
        }

        /// <summary>
        /// Get from database all created members in game.
        /// </summary>
        /// <returns>List of members</returns>
        public List<Member> GetAllMembers() => _db.Members.ToList();
        /// <summary>
        /// Get from database currently member by member ID.
        /// </summary>
        /// <param name="memberID">Searching member id (int)</param>
        /// <returns>Member object</returns>
        public Member GetMemberById(int memberID) =>
            _db.Members.ElementAtOrDefault(memberID);

        public Member GetMemberByName(string name) =>
            _db.Members.FirstOrDefault(m => m.Name == name);

        public List<Member> GetMembersByTeamId(int teamId) =>
            _db.Teams.FirstOrDefault(t => t.Id == teamId).Members.ToList();

        public List<Member> GetMembersByTeamName(string teamName) =>
            _db.Teams.FirstOrDefault(t => t.Name == teamName).Members.ToList();



        /// <summary>
        /// Need to correct this method.
        /// </summary>
        /// <param name="positionName"></param>
        /// <returns></returns>
        public List<Member> GetMembersByPosition(string positionName) =>
            _db.Members
            .Where(m => m.Positions.FirstOrDefault(p => p.Name == positionName).Name == positionName)
            .ToList();
    }
}