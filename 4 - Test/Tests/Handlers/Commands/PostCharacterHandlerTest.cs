using Domain.Commands.Character.Post;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tests.Builders;
using Tests.Mock.Repositorys;

namespace Tests.Handlers.Commands
{

    [TestClass]
    public class PostCharacterHandlerTest : CharacterApiTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda", Profession.Mage)]
        [DataRow("asd_warrior", Profession.Warrior)]
        [DataRow("asdasd_asdas", Profession.Thief)]
        [DataRow("asdasd", Profession.Mage)]
        [DataRow("maria", Profession.Warrior)]
        [DataRow("_thief", Profession.Thief)]
        public async Task Post_Warior_With_Succes(string name, Profession profession)
        {
            //Arrange
            _mockCharacaterRepository.Create();
            _mockCharacaterRepository.Get(new CharacterEntity());
            var command = new PostCharacterCommand() { Character = new CharacterModel(name, profession) };
            //Act

            var result = await _postCharacterHandler.Handle(command, new CancellationToken());

            var atack = GetAttackAttributes(profession);
            var speed = GetSpeedAttributes(profession);
            
            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
            Assert.IsTrue(result.Message == "The was created.");
            Assert.IsTrue(result.Data.AttackAttributes.Dexterity == atack.Dexterity);
            Assert.IsTrue(result.Data.AttackAttributes.Intelligence == atack.Intelligence);
            Assert.IsTrue(result.Data.AttackAttributes.Strength == atack.Strength);
            Assert.IsTrue(result.Data.SpeedAttributes.Strength == speed.Strength);
            Assert.IsTrue(result.Data.SpeedAttributes.Intelligence == speed.Intelligence);
            Assert.IsTrue(result.Data.SpeedAttributes.Dexterity == speed.Dexterity);
        }

    

        [TestMethod]
        [DataTestMethod]
        [DataRow(Profession.Mage)]
        [DataRow(Profession.Warrior)]
        [DataRow(Profession.Thief)]
        public async Task Post_Already_Exists(Profession profession)
        {
            //Arrange
            _mockCharacaterRepository.Create();

            var warrior = new CharacterEntityBuilder().Warrior().Build().FirstOrDefault();
            _mockCharacaterRepository.Get(warrior);
            var command = new PostCharacterCommand() { Character = new CharacterModel(warrior.Name, profession) };
            //Act

            var result = await _postCharacterHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "The character already exists.");

        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("asdasda98" , Profession.Mage)]
        [DataRow("asdasdasdasdasdasdasdasdasdas" , Profession.Warrior)]
        [DataRow("asdasd_asdas---" , Profession.Thief)]
        [DataRow("asdasda98", Profession.Mage)]
        [DataRow("asdasdas99sdasdasdasdas", Profession.Warrior)]
        [DataRow("9999", Profession.Thief)]
        [DataRow("asdasd as", Profession.Thief)]
        [DataRow("", Profession.Thief)]
        [DataRow(" ", Profession.Thief)]
        [DataRow("john", 0)]
        public async Task Post_Already_Request_Is_Not_Valid(string name, Profession profession)
        {
            //Arrange
            _mockCharacaterRepository.Create();
            _mockCharacaterRepository.Get(new CharacterEntity());
            var command = new PostCharacterCommand() { Character = new CharacterModel(name, profession) };
            //Act

            var result = await _postCharacterHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Error);
            Assert.IsTrue(result.Message == "The request is not valid.");
        }


        private Domain.Models.Attribute GetAttackAttributes(Profession profession)
        {
            switch (profession)
            {
                case Profession.Warrior:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 20,
                        Intelligence = 0,
                        Strength = 80,
                    };
                case Profession.Thief:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 100,
                        Intelligence = 25,
                        Strength = 25,
                    };
                case Profession.Mage:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 59,
                        Intelligence = 150,
                        Strength = 20,
                    };
                default: return null;
            }
        }
        private Domain.Models.Attribute GetSpeedAttributes(Profession profession)
        {
            switch (profession)
            {
                case Profession.Warrior:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 60,
                        Intelligence = 20,
                        Strength = 0,
                    };
                case Profession.Thief:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 80,
                        Intelligence = 0,
                        Strength = 0,
                    };
                case Profession.Mage:
                    return new Domain.Models.Attribute
                    {
                        Dexterity = 50,
                        Intelligence = 0,
                        Strength = 20,
                    };
                default: return null;
            }
        }
    }
}
