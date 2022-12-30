using AutoMapper;
using Domain.Models;
using Infrastructure.Data.Entity;

namespace Domain.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterModel, CharacterEntity>()
                 .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name.ToUpper()))
                 .ForMember(m => m.Profession, opt => opt.MapFrom(src => (int)src.Profession))
                 .ForMember(m => m.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                 .ForMember(m => m.Strength, opt => opt.MapFrom(src => src.Strength))
                 .ForMember(m => m.Dexterity, opt => opt.MapFrom(src => src.Dexterity))
                 .ForMember(m => m.Intelligence, opt => opt.MapFrom(src => src.Intelligence));

            CreateMap<CharacterEntity, CharacterModel>()
                .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name.ToUpper()))
                .ForMember(m => m.Profession, opt => opt.MapFrom(src => (int)src.Profession))
                .ForMember(m => m.HitPoints, opt => opt.MapFrom(src => src.HitPoints))
                .ForMember(m => m.Strength, opt => opt.MapFrom(src => src.Strength))
                .ForMember(m => m.Dexterity, opt => opt.MapFrom(src => src.Dexterity))
                .ForMember(m => m.Intelligence, opt => opt.MapFrom(src => src.Intelligence))
                .ForMember(m => m.AttackAttributes, opt => opt.Ignore())
                .ForMember(m => m.SpeedAttributes, opt => opt.Ignore());

            CreateMap<CharacterEntity, CharacterModelToList>()
                    .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name.ToUpper()))
                    .ForMember(m => m.Profession, opt => opt.MapFrom(src => (int)src.Profession))
                    .ForMember(m => m.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<CharacterModelToList, CharacterEntity>()
                   .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Name.ToUpper()))
                   .ForMember(m => m.Profession, opt => opt.MapFrom(src => src.Profession))
                   .ForMember(m => m.Status, opt => opt.MapFrom(src => src.Status))
                   .ForMember(m => m.HitPoints, opt => opt.Ignore())
                   .ForMember(m => m.Strength, opt => opt.Ignore())
                   .ForMember(m => m.Dexterity, opt => opt.Ignore())
                   .ForMember(m => m.Intelligence, opt => opt.Ignore());
        }
    }
}
