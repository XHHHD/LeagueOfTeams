using LOT.DAL.Entities;
using LOT.DAL.Repositories;

namespace LOT.Tests.DataAccessTests
{
    [TestClass]
    public class TeamRankRepositoryTests
    {
        [DataRow("FirstRank")]
        [DataRow("SecondRank")]
        [DataRow("")]
        [TestMethod]
        public void AddAndGettindNewRankInDB(string name)
        {
            //arrange
            var repository = new TeamRankRepository();
            var rankEntity = new TeamRank()
            {
                Name = name,
                Teams = new List<Team>()
            };
            //act
            repository.AddRank(rankEntity);
            //assert
            Assert.AreEqual(rankEntity, repository.GetRank(rankEntity.Id));
            Assert.AreEqual(rankEntity.Id, repository.GetRank(rankEntity.Id).Id);
        }

        [DataRow("1", "")]
        [DataRow("", "2")]
        [DataRow("FirstTest1", "FirstTest2")]
        [TestMethod]
        public void AddAndGettindFewNewRanksInDB(string nameOne, string nameTwo)
        {
            //arrange
            var repository = new TeamRankRepository();
            var firstRankEntity = new TeamRank()
            {
                Name = nameOne,
                Teams = new List<Team>()
            };
            var secondRankEntity = new TeamRank()
            {
                Name = nameTwo,
                Teams = new List<Team>()
            };
            //act
            repository.AddRank(firstRankEntity);
            repository.AddRank(secondRankEntity);
            //assert
            Assert.AreEqual(firstRankEntity, repository.GetRank(firstRankEntity.Id));
            Assert.AreEqual(firstRankEntity.Id, repository.GetRank(firstRankEntity.Id).Id);
            Assert.AreEqual(secondRankEntity, repository.GetRank(secondRankEntity.Id));
            Assert.AreEqual(secondRankEntity.Id, repository.GetRank(secondRankEntity.Id).Id);
        }
    }
}
