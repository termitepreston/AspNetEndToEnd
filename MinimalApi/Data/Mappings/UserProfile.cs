using AutoMapper;
using MinimalApi.Dtos;
using MinimalApi.Entities;

namespace MinimalApi.Data.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Game, GameDto>()
            .ForMember(
                dest => dest.Genres,
                opt => opt.MapFrom(
                    src => src.GameGenres.Select(relation => relation.GenreId))
                );
    }
}