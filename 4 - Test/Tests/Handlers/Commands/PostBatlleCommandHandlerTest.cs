using Domain.Commands.Batlle;
using Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using Tests.Builders;
using Tests.Mock.Repositorys;

namespace Tests
{
    [TestClass]
    public class PostBatlleCommandHandlerTest : CharacterApiTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("MageName", "ThiefName")]
        [DataRow("warriorName", "MageName")]
        [DataRow("warriorName", "ThiefName")]
        [DataRow("ThiefName", "MageName")]
        public async Task Post_Warior_With_Succes(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo= characterTwo };

            //Act
            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda", "asdasda")]
        [DataRow("asd_warrior", "asd_warrior")]
        [DataRow("asdasd_asdas", "asdasd_asdas")]
        public async Task Post_Warior_With_Character_Canot_Be_The_Same(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act
            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "The characters canot be the same");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda", "asasddasda")]
        [DataRow("asd_warrior", "asd_wasaarrior")]
        [DataRow("asdasd_asdas", "asdasasas_asdas")]
        public async Task Post_Warior_The_Character_One_Not_exists(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act
            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == $"The character {characterOne} not exists.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("MageName", "asdasda")]
        [DataRow("warriorName", "asd_warrior")]
        [DataRow("ThiefName", "asdasd_asdas")]
        public async Task Post_Warior_The_Character_Two_Not_exists(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act
            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == $"The character {characterTwo} not exists.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("warriorNameDead", "asdasda")]
        [DataRow("mageNameDead", "asd_warrior")]
         public async Task Post_Warior_The_CharacterOne_IsDead(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act

            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == $"The character {characterOne} is dead.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("MageName", "warriorNameDead")]
        [DataRow("warriorName", "mageNameDead")]
        public async Task Post_Warior_The_CharacterTwo_IsDead(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act

            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == $"The character {characterTwo} is dead.");
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda98", "ThiefName")]
        [DataRow("asdasdasdasdasdasdasdasdasdas", "ThiefName")]
        [DataRow("asdasd_asdas---", "ThiefName")]
        [DataRow("ThiefName", "asdasda98")]
        [DataRow("ThiefName", "asdasdas99sdasdasdasdas")]
        [DataRow("ThiefName", "9999")]
        [DataRow("ThiefName", "asdasd as")]
        [DataRow("ThiefName", "")]
        [DataRow("ThiefName", " ")]
        public async Task Post_Warior_The_Request_Is_Invalid(string characterOne, string characterTwo)
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.GetFromList(characters, characterOne, characterTwo);
            var command = new PostBatlleCommand() { CharacterOne = characterOne, CharacterTwo = characterTwo };

            //Act

            var result = await _postBatlleCommandHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "The request is invalid.");
        }
    }
}