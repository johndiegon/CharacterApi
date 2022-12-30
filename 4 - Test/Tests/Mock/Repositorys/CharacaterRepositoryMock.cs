using Infrastructure.Data.Entity;
using Infrastructure.Data.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Mock.Repositorys
{
    public static class CharacaterRepositoryMock
    {
        public static Mock<ICharacaterRepository> CreateMock() =>
            new Mock<ICharacaterRepository>(){ CallBase = true };

        public static Mock<ICharacaterRepository> Get(this Mock<ICharacaterRepository> mock , CharacterEntity @returns)
        {
            mock.Setup(p => p.Get(It.IsAny<string>())).ReturnsAsync(@returns);
            return mock;
        }

        public static Mock<ICharacaterRepository> Get(this Mock<ICharacaterRepository> mock, List<CharacterEntity> @returns)
        {
            mock.Setup(p => p.Get()).ReturnsAsync(@returns);
            return mock;
        }

        public static Mock<ICharacaterRepository> GetFromList(this Mock<ICharacaterRepository> mock, List<CharacterEntity> @returns, string charOne, string charTwo)
        {
            mock.SetupSequence(p => p.Get(It.IsAny<string>()))
                .ReturnsAsync(@returns.Where(r => r.Name == charOne).FirstOrDefault())
                .ReturnsAsync(@returns.Where(r => r.Name == charTwo).FirstOrDefault());
            return mock;
        }

        public static Mock<ICharacaterRepository> GetFromList(this Mock<ICharacaterRepository> mock, List<CharacterEntity> @returns, string name)
        {
            mock.Setup(p => p.Get(It.IsAny<string>()))
                .ReturnsAsync(@returns.Where(r => r.Name == name).FirstOrDefault());
            return mock;
        }

        public static Mock<ICharacaterRepository> Create(this Mock<ICharacaterRepository> mock)
        {
            mock.Setup(p => p.Crete(It.IsAny<CharacterEntity>()));
            return mock;
        }

        public static Mock<ICharacaterRepository> Delete(this Mock<ICharacaterRepository> mock)
        {
            mock.Setup(p => p.Delete(It.IsAny<string>()));
            return mock;
        }

        public static Mock<ICharacaterRepository> Update(this Mock<ICharacaterRepository> mock)
        {
            mock.Setup(p => p.Update(It.IsAny<CharacterEntity>()));
            return mock;
        }
    }
}
