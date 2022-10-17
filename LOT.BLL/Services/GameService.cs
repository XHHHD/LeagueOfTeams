using LOT.BLL.Models.Members;
using LOT.BLL.Models.Ranks;
using LOT.BLL.Models.Teams;
using LOT.BLL.Models;
using LOT.BLL.Services.Ranks;
using LOT.BLL.Services.Teams;
using LOT.BLL.Models.Positions;
using LOT.BLL.Enums;

namespace LOT.BLL.Services
{
    public class GameService
    {
        TeamService teamService;
        TeamsNamesService namesService;
        public GameService()
        {
            teamService = new();
            namesService = new();
        }

        public void GenerateGameEnvirement(int expectedTeamsCount = 99)
        {
            int teamsCount = expectedTeamsCount - teamService.GetAllTeams().Count();
            if (teamsCount > 0)
            {
                GenerateTeamRanks(teamsCount / TeamRankModel.maxTeamsCount);
                if (teamsCount % 20 > 0)
                { }
            }
        }
        private List<TeamRankModel> GenerateTeamRanks(int ranksCount)
        {
            List<TeamRankModel> allRanks = new();
            for (int i = 1; i <= ranksCount; i++)
            {
                allRanks.Add(GenerateTeamRank(i));
            }
            return allRanks;
        }
        private TeamRankModel GenerateTeamRank(int rankNum)
        {
            TeamRankModel teamRankModel = new TeamRankModel()
            {
                Name = "Rank" + rankNum.ToString()
            };
            TeamsRankService.Add(teamRankModel);
            for (int i = 1; i <= 20; i++)
            {
                GenerateTeam(teamRankModel);
            }
            var rankFromDb = TeamsRankService.GetRank(teamRankModel.Name);
            return rankFromDb;
        }

        //
        //
        private TeamModel GenerateTeam(TeamRankModel rank)
        {
            var teamModel = new TeamModel();
            teamModel.TeamRank = rank;
            return teamModel;
        }

        private TeamModel GenerateEmptyTeamModel()
        {
            var team = new TeamModel()
            {
                Name = namesService.GetNewTeamName(),

            };
            return team;
        }

        //
        //
        private MemberModel GenerateMember(TeamModel team)
        {
            throw new NotImplementedException();
        }

        //
        //
        private PositionModel GeneratePosition(MemberModel member)
        {
            throw new NotImplementedException();
        }

        private MemberRankModel GenerateMemberRank(int rankNum)
        {
            MemberRankModel memberRankModel = new()
            {
                Name = "Rank" + rankNum.ToString()
            };

            MembersRankService.Add(memberRankModel);

            return memberRankModel;
        }

        /// <summary>
        /// Generate test user with some stats and submodels(team, team rank,
        /// member, member rank, position).
        /// </summary>
        /// <returns>User model</returns>
        public UserModel GetTestUserModeel()
        {
            var user = new UserModel()
            {
                Id = 1,
                Level = 1,
                Name = "Test Player"
            };
            var team = new TeamModel()
            {
                Id = 1,
                Name = "Test Team",
                ShortName = "TES",
                Description = "This is test team",
                Expiriance = 0,
                Energy = 0,
                MaxEnergy = 100,
                Power = 0,
                Health = 0,
                Teamplay = 0,
                RankPoints = 0,
                UserId = 1,
                User = user,
                Members = new()
            };
            var teamRank = new TeamRankModel()
            {
                Id = 1,
                Name = "Test rank",
                Teams = new List<TeamModel>() { team }
            };
            var member = new MemberModel()
            {
                Id = 1,
                Name = "Test Player",
                Age = 20,
                Power = 10,
                Energy = 10,
                MaxEnergy = 100,
                MentalPower = 10,
                MentalResistance = 10,
                Teamplay = 10,
                Expiriance = 100,
                SkillPoints = 0,
                RankPoints = 0,
                Positions = new()
            };
            var memberRank = new MemberRankModel()
            {
                Id = 1,
                Name = "Test member rank",
                Members = new List<MemberModel>() { member }
            };
            var position = new PositionModel()
            {
                Id = 1,
                Name = PositionsNames.Top,
                Expiriance = 0,
                Rank = 0,
                Power = 10,
                Happines = 10,
                Defence = 10,
                Health = 10,
                Member = member
            };
            member.Positions.Add(position);
            member.MemberRankId = memberRank.Id;
            team.TeamRank = teamRank;
            team.Members.Add(member);
            user.Team = team;
            return user;
        }
    }
}
