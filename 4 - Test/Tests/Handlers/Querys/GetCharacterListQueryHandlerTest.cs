using Domain.Enums;
using Domain.Queries.Character.GetList;
using Infrastructure.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tests.Builders;
using Tests.Mock.Repositorys;


namespace Tests.Handlers.Querys
{

    [TestClass]
    public class GetCharacterListQueryHandlerTest : CharacterApiTest
    {

        [TestMethod]
        [DataTestMethod]  
        public async Task GetListDetails_With_Data_Succes()
        {
            //Arrange
            var characters = new CharacterEntityBuilder().All().Build();
            _mockCharacaterRepository.Get(characters);

            var command = new GetCharacterListQuery();
            //Act

            var result = await _getCharacterListQueryHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
            Assert.IsTrue(result.Data.Count > 0);
        }

        [TestMethod]
        [DataTestMethod]
        public async Task GetListDetails_Without_Data_Succes()
        {
            //Arrange
            _mockCharacaterRepository.Get(new List<CharacterEntity>());

            var command = new GetCharacterListQuery();
            //Act

            var result = await _getCharacterListQueryHandler.Handle(command, new CancellationToken());

            //Assert
            Assert.IsTrue(result.Status == StatusRequest.Sucessed);
            Assert.IsTrue(result.Data.Count == 0);
        }
    }
}
