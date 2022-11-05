﻿using AutoMapper;
using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Positions;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Members
{
    public class MemberService
    {
        private const byte defoultAgeConst = 14;
        private const int memberUpperPowerRandomConst = 5;
        private const int memberLowerPowerRandomConst = 0;
        private const int memberUpperMentalPowerRandomConst = 5;
        private const int memberLowerMentalPowerRandomConst = 0;
        private const int memberUpperTeamplayRandomConst = 100;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int memberUpperMaxEnergyRandomConst = 22;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int memberLowerMaxEnergyRandomConst = 18;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int memberUpperMentalResistanceRandomConst = 22;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int memberLowerMentalResistanceRandomConst = 16;

        private readonly Random random;
        private readonly IMapper mapper;
        private readonly MemberRepository repository;
        private readonly NickGenerator nickGenerator;
        private readonly PositionService positionService;

        public MemberService()
        {
            random = new();
            repository = new();
            nickGenerator = new();
            positionService = new();
            mapper = MappingHelper.GetMapper();
        }

        /// <summary>
        /// Create member entity in database, and actualizing member model ID.
        /// </summary>
        /// <param name="model">Member model.</param>
        /// <exception cref="MemberServicesException"></exception>
        public void AddMember(MemberModel model)
        {
            if (model is null)
                throw new MemberServicesException("Adding model is NULL!");
            else
            {
                var entity = mapper.Map<Member>(model);
                repository.AddMember(entity);
                model.Id = entity.Id;
            }
        }

        public void RemoveMember(int id) => repository.RemoveMember(id);

        public void UpdateMember(MemberModel model)
        {
            if (model is null)
                throw new MemberServicesException("Updating model is NULL!");
            else
            {
                var entity = mapper.Map<Member>(model);
                repository.UpdateMember(entity);
                model.Id = entity.Id;
            }
        }

        public void SaveMember(MemberModel model)
        {
            if (model is null)
                throw new MemberServicesException("Member model is NULL!");
            else
            {
                var entity = mapper.Map<Member>(model);
                repository.SaveMember(entity);
                model.Id = entity.Id;
            }
        }

        /// <summary>
        /// Searcing in database entity`s of member and position.
        /// Add position entity on member list of position`s. Return refreshed member model.
        /// </summary>
        /// <param name="memberId">Member model ID.</param>
        /// <param name="position">Position model ID.</param>
        /// <returns>Actualized member model.</returns>
        /// <exception cref="MemberServicesException"></exception>
        public MemberModel AddPositionInTheMember(int memberId, PositionModel position)
        {
            if (position is null)
                throw new MemberServicesException("Position can`t be added, coz position is NULL!");
            else
                return mapper.Map<MemberModel>(repository.AddPositionToTheMember(memberId, mapper.Map<Position>(position)));
        }

        /// <summary>
        /// Get all members from database.
        /// </summary>
        /// <returns>Return members collection or NULL.</returns>
        public IEnumerable<MemberModel> GetAll()
        {
            if (repository.GetAll() == null || repository.GetAll().Count() == 0)
                return null;
            else
                return mapper.Map<IEnumerable<MemberModel>>(repository.GetAll());
        }

        /// <summary>
        /// Get all member nicks.
        /// </summary>
        /// <returns>List of members names.</returns>
        public List<string> GetAllNames()
        {
            if (repository.GetAll() == null || repository.GetAll().Count() == 0)
                return null;
            else
                return mapper.Map<List<string>>(repository.GetAllNames());
        }

        /// <summary>
        /// Get all members, who belong selected team.
        /// </summary>
        /// <param name="teamId">Selected TeamModel ID.</param>
        /// <returns>Members collection or NULL.</returns>
        public IEnumerable<MemberModel> GetMembersOfTeam(int teamId)
        {
            if (repository.GetMembersByTeamId(teamId) == null || repository.GetMembersByTeamId(teamId).Count() == 0)
                return null;
            else
                return mapper.Map<IEnumerable<MemberModel>>(repository.GetMembersByTeamId(teamId));
        }

        /// <summary>
        /// Get member from database by his ID.
        /// </summary>
        /// <param name="id">ID of member.</param>
        /// <returns>Member model or NULL.</returns>
        public MemberModel GetMember(int id)
        {
            if (repository.GetMemberById(id) == null)
                return null;
            else
                return mapper.Map<MemberModel>(repository.GetMemberById(id));
        }

        /// <summary>
        /// Return free id to use, starting from 1.
        /// </summary>
        /// <returns>Free member int ID</returns>
        public int GetFreeMemberId() =>
            repository.GetLast() != null ?
            ++repository.GetLast().Id
            : 1;

        /// <summary>
        /// Make new member.
        /// </summary>
        /// <param name="exp">User expiriance.</param>
        /// <returns>New Member.</returns>
        public MemberModel GenerateNewMember(PositionsNames expectedPosition, uint exp)
        {
            var member = GenerateNewMember(expectedPosition);
            int level = (int)(exp / 1000);
            //
            member.Age = (byte)random.Next(0, level / 3);
            if (member.Age > 30)
                member.Age = 30;
            //
            member.MaxEnergy += random.Next(-1, level) * 5;
            member.Energy = member.MaxEnergy;

            ///Exp is uint type and it`s can`t be negative. Here I trying to randomize
            ///negative exp fore member by user exp. If user will have too low exp and
            ///random get too low value - member will be protected from getting
            ///negative exp value.
            member.Expiriance = exp + (uint)random.Next(0, 2780);
            if ((int)(member.Expiriance - exp) - 2000 > 0)
                member.Expiriance -= 2000;
            else
                member.Expiriance = 0;
            //
            UpdateMember(member);
            //
            return member;
        }

        //It`s work, but NEED TO REMAKE coz it is repeating!
        public MemberModel GenerateNewMember(uint exp)
        {
            var member = GenerateNewMember();
            int level = (int)(exp / 1000);
            //
            member.Age = (byte)random.Next(0, level / 3);
            if (member.Age > 30)
                member.Age = 30;
            //
            member.MaxEnergy += random.Next(-1, level) * 5;
            member.Energy = member.MaxEnergy;

            ///Exp is uint type and it`s can`t be negative. Here I trying to randomize
            ///negative exp fore member by user exp. If user will have too low exp and
            ///random get too low value - member will be protected from getting
            ///negative exp value.
            member.Expiriance = exp + (uint)random.Next(0, 2780);
            if ((int)(member.Expiriance - exp) - 2000 > 0)
                member.Expiriance -= 2000;
            else
                member.Expiriance = 0;
            //
            SaveMember(member);
            //
            return member;
        }

        public MemberModel GenerateNewMember(PositionsNames expectedPosition)
        {
            var member = GenerateEmptyMember();
            var position = positionService.CreateEmptyPosition((int)member.Level);
            position.Name = expectedPosition;
            AddPositionInTheMember(member.Id, position );
            //positionService.CreatePositionInMember(member, expectedPosition);
            //UpdateMember(member);
            return member;
        }

        public MemberModel GenerateNewMember()
        {
            var member = GenerateEmptyMember();
            var randomPositionName = positionService.GetNewRandomPositionName();
            var position = positionService.CreateEmptyPosition((int)member.Level);
            position.Name = randomPositionName;
            AddPositionInTheMember(member.Id, position);
            //positionService.CreatePositionInMember(member, randomPositionName);
            //UpdateMember(member);
            return member;
        }

        /// <summary>
        /// Generate empty default member without using any parameters, and NOT REGISTRAITED in database.
        /// </summary>
        /// <returns></returns>
        public MemberModel GenerateEmptyMember()
        {
            var member = new MemberModel()
            {
                CreationDate = DateTime.Now,
                LastChanges = DateTime.Now,
                Name = nickGenerator.GenerateNewNick(),
                Age = (byte)(defoultAgeConst + random.Next(0, 2)),
                MaxEnergy = random.Next(memberLowerMaxEnergyRandomConst, memberUpperMaxEnergyRandomConst) * 5,
                Power = random.Next(memberLowerPowerRandomConst, memberUpperPowerRandomConst),
                MentalPower = random.Next(memberLowerMentalPowerRandomConst, memberUpperMentalPowerRandomConst),
                MentalResistance = random.Next(memberLowerMentalResistanceRandomConst, memberUpperMentalResistanceRandomConst) * 5,
                Teamplay = random.Next(0, memberUpperTeamplayRandomConst),
                Expiriance = 0,
                SkillPoints = 0,
                RankPoints = 0,
                Positions = new(),
                Trails = new()
            };
            member.Energy = member.MaxEnergy;

            AddMember(member);

            return member;
        }
    }
}
