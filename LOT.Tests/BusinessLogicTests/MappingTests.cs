using LOT.BLL;
using LOT.BLL.Models;
using LOT.DAL.Entities;

namespace LOT.Tests.BusinessLogicTests
{
    [TestClass]
    public class MappingTests
    {
        [DataRow(1, "Player", "pass")]
        [DataRow(35, "o", "32g2")]
        [DataRow(456, "", "")]
        [TestMethod]
        public void AutomapperMapsEntitiesCorrecctly(int id, string name, string password)
        {
            //arrange
            var mapper = MappingHelper.GetMapper();
            var team = GetTestTeamEntity(name);

            var userEntity = new User()
            {
                Id = id,
                Name = name,
                Password = password,
                Team = team
            };
            var expectedModel = new UserModel()
            {
                Id = id,
                Name = name,
                Password = password
            };

            //act

            var actualMappedModel = mapper.Map<UserModel>(userEntity);

            //assert
            Assert.AreEqual(expectedModel.Name, actualMappedModel.Name);
            Assert.AreEqual(expectedModel.Id, actualMappedModel.Id);
            Assert.AreEqual(expectedModel.Password, actualMappedModel.Password);
        }

        private Team GetTestTeamEntity(string name)
        {
            return new Team()
            {
                Name = name,
                ShortName = name,
                Description = ""
            };
        }
    }
}