using Domain.Enums;
using Domain.Queries.Character.GetDetails;
using Infrastructure.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Tests.Builders;
using Tests.Mock.Repositorys;

namespace Tests.Handlers.Querys
{
    [TestClass]
    public class GetCharacterDetailsQueryHandlerTest : CharacterApiTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda98")]
        [DataRow("asdasdasdasdasdasdasdasdasdas")]
        [DataRow("asdasd_asdas---")]
        [DataRow("asdasda98")]
        [DataRow("asdasdas99sdasdasdasdas")]
        [DataRow("9999")]
        [DataRow("asdasd as")]
        [DataRow("")]
        [DataRow(" ")]
        public async Task GetDetails_The_Name_Is_Not_Valid(string name)
        {
            //Arrange
            _mockCharacaterRepository.Get(new CharacterEntity());
            var command = new GetCharacterDetailsQuery() { Name = name };
            //Act

            var result = await _getCharacterDetailsQueryHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "The name  is not valid.");
         
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("MageName")]
        [DataRow("ThiefName")]
        [DataRow("warriorName")]
        [DataRow("warriorNameDead")]
        [DataRow("mageNameDead")]
        public async Task GetDetails_With_Succes(string name)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, name);

            var command = new GetCharacterDetailsQuery() { Name = name };
            //Act

            var result = await _getCharacterDetailsQueryHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
            Assert.IsTrue(result.Data.Name == name);

        }
    }
}
