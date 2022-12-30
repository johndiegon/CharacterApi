using AutoMapper;
using Domain.Commands.Batlle;
using Domain.Commands.Character.Delete;
using Domain.Commands.Character.Post;
using Domain.Profiles;
using Domain.Queries.Character.GetDetails;
using Domain.Queries.Character.GetList;
using Infrastructure.Data.Interfaces;
using MediatR;
using Moq;
using System.Threading;
using Tests.Handlers.Querys;

namespace Tests
{
    public class CharacterApiTest
    {
        protected Mock<ICharacaterRepository> _mockCharacaterRepository { get; private set; }
        protected Mock<IMediator> _mockMediator { get; private set; }   
        protected PostCharacterHandler _postCharacterHandler { get; private set; }
        protected DeleteCharacterHandler _deleteCharacterHandler { get; private set; }
        protected PostBatlleCommandHandler _postBatlleCommandHandler { get; private set; }
        protected GetCharacterDetailsQueryHandler _getCharacterDetailsQueryHandler { get; private set; }
        protected GetCharacterListQueryHandler _getCharacterListQueryHandler { get; private set; }
        protected ICharacaterRepository _characaterRepository => _mockCharacaterRepository.Object;

        protected IMapper _mapper;
        protected IMediator _mediator => _mockMediator.Object;

        public CharacterApiTest()
        {
            LoadRepositories();
            LoadServices();
        }

        private void LoadRepositories()
        {
            _mockCharacaterRepository = new Mock<ICharacaterRepository>()
            {
                CallBase = true
            };

            _mockMediator = new Mock<IMediator>()
            {
                CallBase = true
            };
        }
        private void LoadServices()
        {

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CharacterProfile()));
            _mapper = new Mapper(configuration);

            _postCharacterHandler = new PostCharacterHandler(_characaterRepository, _mapper);
            _deleteCharacterHandler = new DeleteCharacterHandler(_characaterRepository);
            _postBatlleCommandHandler = new PostBatlleCommandHandler(_characaterRepository, _mapper);
            _getCharacterDetailsQueryHandler = new GetCharacterDetailsQueryHandler(_characaterRepository, _mapper);
            _getCharacterListQueryHandler = new GetCharacterListQueryHandler(_characaterRepository, _mapper);
            
        }
    }
}
