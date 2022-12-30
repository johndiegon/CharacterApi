using Domain.Commands.Character.Delete;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Tests.Mock.Repositorys;

namespace Tests.Handlers.Commands
{
    [TestClass]
    public class DeleteCharacterHandlerTest : CharacterApiTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda")]
        [DataRow("asd_warrior")]
        [DataRow("asdasd_asdas")]
        [DataRow("asdasd")]
        [DataRow("maria")]
        [DataRow("_thief")]
        public async Task Delete_WithSucces(string name)
        {
            //Arrange
            _mockCharacaterRepository.Delete();
            var command = new DeleteCharacterCommand() {Name = name };
            //Act

            var result = await _deleteCharacterHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
            Assert.IsTrue(result.Message == "The character was delete.");
        }

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
        public async Task Delete_The_Name_Is_Invalid(string name)
        {
            //Arrange
            _mockCharacaterRepository.Delete();
            var command = new DeleteCharacterCommand() { Name = name };
            //Act

            var result = await _deleteCharacterHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "This name is invalid.");
        }

    }
}
