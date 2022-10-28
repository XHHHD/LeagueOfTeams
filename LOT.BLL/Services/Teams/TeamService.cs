using AutoMapper;
using LOT.BLL.Enums;
using LOT.BLL.Exceptions;
using LOT.BLL.Models.DTO;
using LOT.BLL.Models.Members;
using LOT.BLL.Models.Teams;
using LOT.BLL.Services.Members;
using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.BLL.Services.Teams
{
    public class TeamService
    {
        private const int teamUpperPowerRandomConst = 5;
        private const int teamLowerPowerRandomConst = 0;
        private const int teamUpperTeamplayRandomConst = 5;
        private const int teamLowerTeamplayRandomConst = -1;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int teamUpperMaxEnergyRandomConst = 22;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int teamLowerMaxEnergyRandomConst = 18;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int teamUpperHealthRandomConst = 22;
        /// <summary>
        /// NOTA BENE!
        /// This parameter will be multiplicated by 5 afte randomizing!
        /// </summary>
        private const int teamLowerHealthRandomConst = 18;

        private readonly Random random;
        private readonly IMapper mapper;
        private readonly TeamRepository repository;
        private readonly TeamsNamesService namesService;
        private readonly MemberService memberService;

        public TeamService()
        {
            random = new();
            repository = new();
            namesService = new();
            memberService = new();
            mapper = MappingHelper.GetMapper();
        }

        public void AddTeam(TeamModel team)
        {
            if (team != null)
                repository.Add(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to create null team!");
        }

        public void UpdateTeame(TeamModel team)
        {
            if (team != null)
                repository.UpdateTeam(mapper.Map<Team>(team));
            else
                throw new TeamServicesException("Trying to update null team!");
        }

        public void RemoveTeam(int id)
        {
            var teamToRemove = repository.GetTeam(id);
            if (teamToRemove == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveTeam(teamToRemove.Id);
        }

        public void RemoveTeamById(int id)
        {
            if (repository.GetTeam(id) == null)
                throw new TeamServicesException("Removing team was failed! Can`t find current team in data.");
            else
                repository.RemoveAsync(id);
        }

        public TeamModel GetTeamFromDB(int id) =>
            mapper.Map<TeamModel>(repository.GetTeam(id));

        public IEnumerable<MemberModel> GetMembersOfTeamFromDB(int id) =>
            mapper.Map<IEnumerable<MemberModel>>(repository.GetTeamMembers(id));

        public IEnumerable<TeamModel> GetAllTeams() =>
            mapper.Map<IEnumerable<TeamModel>>(repository.GetAll());

        /// <summary>
        /// Generate team with members.
        /// </summary>
        /// <returns></returns>
        public TeamModel GetFullTeamModel()
        {
            var team = GetTeamModelWhithoutMembers();
            //
            var positions = Enum.GetValues(typeof(PositionsNames));
            foreach (PositionsNames position in positions)
            {
                team.Members.Add(memberService
                    .GenerateNewMember(position));
            }
            //
            UpdateTeame(team);
            //
            return team;
        }

        /// <summary>
        /// Generate new random team without members.
        /// </summary>
        /// <returns>Team model.</returns>
        public TeamModel GetTeamModelWhithoutMembers()
        {
            var team = GetEmptyTeamModel();
            //
            team.Name = namesService
                .GetNewTeamName();
            //
            team.ShortName = namesService
                .GetNewShortName(team.Name);
            //
            team.MaxEnergy = random
                .Next(teamLowerMaxEnergyRandomConst, teamUpperMaxEnergyRandomConst) * 5;
            team.Energy = team.MaxEnergy;
            //
            team.Health = random
                .Next(teamLowerHealthRandomConst, teamUpperHealthRandomConst) * 5;
            //
            team.Power = random
                .Next(teamLowerPowerRandomConst, teamUpperPowerRandomConst);
            //
            team.Teamplay = random
                .Next(teamLowerTeamplayRandomConst, teamUpperTeamplayRandomConst);
            //
            repository
                .Add(mapper
                .Map<Team>(team));
            //
            return team;
        }

        //Generate new team for user by his DTO instruction.
        public TeamModel GetTeamModelWhithoutMembers(TeamRegistrationDTO newTeamDTO)
        {
            var team = GetFullTeamModel();
            //
            team.Name = newTeamDTO.Name;
            //
            team.ShortName = newTeamDTO.ShortName;
            //
            team.Description = newTeamDTO.Description;
            //
            repository
                .UpdateTeam(mapper
                .Map<Team>(team));
            return team;
        }

        /// <summary>
        /// Method create new empty team model with empty Name, ShortName and without Id.
        /// </summary>
        /// <returns>Empty PositionModel object.</returns>
        private static TeamModel GetEmptyTeamModel()
        {
            var team = new TeamModel()
            {
                Name = "",
                ShortName = "",
                Description = "This team has no any description.",
                Image = "/Resources/Default/icons8-ос-free-bsd-100-white.png",
                Expiriance = 0,
                MaxEnergy = 100,
                Energy = 100,
                Health = 100,
                Power = 0,
                Teamplay = 0,
                RankPoints = 0,
                TeamRank = new()
            };
            return team;
        }

        /// <summary>
        /// Add expiriance to currently team.
        /// </summary>
        /// <param name="team">Team model.</param>
        /// <param name="addedValue">Added expiriance value.</param>
        public void AddExpiriance(TeamModel team, uint addedValue)
        {
            var levelWas = team.Level;
            team.Expiriance += addedValue;
            var levelDifference = (int)(team.Level - levelWas);
            if (levelDifference > 0)
                LevelUp(team, levelDifference);
        }
        /// <summary>
        /// Up currently team stats after here level is growed up.
        /// </summary>
        /// <param name="team">Team model.</param>
        /// <param name="levelDifference">Level difference value.</param>
        private void LevelUp(TeamModel team, int levelDifference)
        {
            team.MaxEnergy += levelDifference * 5;
            team.Health += levelDifference * 5;
            team.Power += levelDifference;
            team.Teamplay += levelDifference;
        }
    }
}
