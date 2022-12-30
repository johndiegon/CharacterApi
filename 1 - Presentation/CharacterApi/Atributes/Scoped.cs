using Domain.Commands.Batlle;
using Domain.Commands.Character.Delete;
using Domain.Commands.Character.Post;
using Domain.Models;
using Domain.Models.Command;
using Domain.Queries.Character.GetDetails;
using Domain.Queries.Character.GetList;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Repositorys;
using MediatR;

namespace CharacterApi.Atributes
{
    public static class Scoped
    {
        public static void Add(IServiceCollection services)
        {

            services.AddScoped<ICharacaterRepository, CharacaterRepository>();

            services.AddTransient<IRequestHandler<PostCharacterCommand, CommandResponse<CharacterModel>>, PostCharacterHandler>();
             services.AddTransient<IRequestHandler<DeleteCharacterCommand, CommandResponse<object>>, DeleteCharacterHandler>();
            services.AddTransient<IRequestHandler<GetCharacterDetailsQuery, GetCharacterDetailsResponse>, GetCharacterDetailsQueryHandler>();
            services.AddTransient<IRequestHandler<GetCharacterListQuery, GetCharacterListResponse>, GetCharacterListQueryHandler>();
            services.AddTransient<IRequestHandler<PostBatlleCommand, PostBatlleCommandResponse>, PostBatlleCommandHandler>();
        }
    }
}
