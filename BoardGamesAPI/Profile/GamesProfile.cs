using BoardGamesAPI.Dtos;
using BoardGamesAPI.Model;
using AutoMapper;

namespace BoardGamesAPI.Profile
{
    public class GamesProfile : AutoMapper.Profile
    {

        //AutoMapper to map the Dto to Model
        // source -> target
        public GamesProfile()
        {
            CreateMap<CreateGameDto, Games>();
            CreateMap<Games, GetGamesDto>();
            CreateMap<UpdateGameDto, Games>();
            CreateMap<RemoveGameDto, Games>();
        }
    }
}
