using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Data.Entity;
using Infrastructure.Data.Interfaces;
using MediatR;

namespace Domain.Commands.Batlle
{
    public class PostBatlleCommandHandler : IRequestHandler<PostBatlleCommand, PostBatlleCommandResponse>
    {
        public readonly ICharacaterRepository _characaterRepository;
        public readonly IMapper _mapper;

        public PostBatlleCommandHandler(ICharacaterRepository characaterRepository,
                                     IMapper mapper
                                   )
        {
            _characaterRepository = characaterRepository;
            _mapper = mapper;
        }

        public async Task<PostBatlleCommandResponse> Handle(PostBatlleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IsValid())
                {

                    if (request.CharacterOne == request.CharacterTwo)
                        return Error("The characters canot be the same");

                    var characterOne = _mapper.Map<CharacterModel>(_characaterRepository.Get(request.CharacterOne).Result);
                    if (characterOne == null || characterOne.Name == null)
                        return Error($"The character {request.CharacterOne} not exists.");

                    if (characterOne.Status == StatusCharacter.Dead)
                        return Error($"The character {request.CharacterOne} is dead.");
                
                    var characterTwo = _mapper.Map<CharacterModel>(_characaterRepository.Get(request.CharacterTwo).Result);
                    if (characterTwo == null)
                        return Error($"The character {request.CharacterTwo} not exists.");

                    if (characterTwo.Status == StatusCharacter.Dead)
                        return Error($"The character {request.CharacterTwo} is dead.");

                    var logBattle = new LogBattleModel();

                    var isSetFirst = false;

                    while (isSetFirst)
                        isSetFirst = SetFirst(characterOne, characterTwo, logBattle);

                    Battle( logBattle.CharacterFirst == characterOne.Name ? characterOne : characterTwo
                          , logBattle.CharacterFirst == characterOne.Name ? characterTwo : characterOne
                          , logBattle
                          );

                    await _characaterRepository.Update(_mapper.Map<CharacterEntity>(characterOne));
                    await _characaterRepository.Update(_mapper.Map<CharacterEntity>(characterTwo));

                    return new PostBatlleCommandResponse
                    {
                        Data = logBattle,
                        Status = StatusRequest.Sucessed,
                    };
                }
                else
                {
                    return Error("The request is invalid.");
                }
            }
            catch (Exception ex)
            {
                return Error($"Forgive me for the unforeseen, but an internal error occurred: {ex.Message}.");
            }
        }

        private PostBatlleCommandResponse Error(string message)
        {
            return new PostBatlleCommandResponse
            {
                Status = StatusRequest.Error,
                Message = message,
            };
        }

        private bool SetFirst(CharacterModel characterOne, CharacterModel characterTwo, LogBattleModel logBattle)
        {
            var speedCharacterOne = characterOne.CalculateSpeed();
            var speedCharacterTwo = characterTwo.CalculateSpeed();

            if ( speedCharacterOne > speedCharacterTwo)
            {
                logBattle.Log.Add($"{characterOne.Name} ({speedCharacterOne}) foi mais veloz que o {characterTwo.Name}, e irá começar");
                logBattle.CharacterFirst = characterOne.Name;
                logBattle.CharacterSecond = characterTwo.Name;
                return true;
            }
            else
            {
                logBattle.Log.Add($"{characterTwo.Name} ({speedCharacterTwo}) foi mais veloz que o {characterOne.Name}, e irá começar");
                logBattle.CharacterFirst = characterTwo.Name;
                logBattle.CharacterSecond = characterOne.Name;
                return true;
            }
            return false;
        }
  
        private void Battle(CharacterModel first, CharacterModel second, LogBattleModel logBattle)
        {
            var bFirst = true;
            
            while (first.HitPoints > 0 && second.HitPoints > 0)
            {
                if (bFirst)
                {
                    var atack = first.CalculateAtack();
                    second.HitPoints -= atack;
                    logBattle.Log.Add($"{first.Name} atacou {second.Name} com {atack}, {second.Name} com {second.HitPoints}");
                
                }
                else
                {
                    var atack = second.CalculateAtack();
                    first.HitPoints -= atack;
                    logBattle.Log.Add($"{first.Name} atacou {first.Name} com {atack}, {first.Name} com {second.HitPoints}");
                }

                bFirst = bFirst ? false : true;
            }

            if(second.HitPoints <= 0)
                logBattle.Log.Add($"{first.Name} venceu a batalha! {first.Name} ainda tem {first.HitPoints} pontos de vida");
            else
                logBattle.Log.Add($"{second.Name} venceu a batalha! {second.Name} ainda tem {second.HitPoints} pontos de vida");

        }


    }
}
