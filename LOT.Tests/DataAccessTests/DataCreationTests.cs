using LOT.DAL.Entities;
using LOT.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOT.Tests.DataAccessTests
{
    [TestClass]
    public class DataCreationTests
    {
        [DataRow("ADM", "123")]
        [TestMethod]
        public void UserCreation(string name, string pass)
        {
            //arrange
            var repo = new UserRepository();
            var user = new User()
            {
                Name = name,
                Password = pass
            };
            //act
            repo.AddUser(user);
            //assert
            Assert.IsNotNull(repo.GetAllUsers());
        }
        //arrange
        //act
        //assert
    }
}
