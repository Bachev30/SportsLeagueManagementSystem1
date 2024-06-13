using AutoMapper;
using SportsLeagueManagement.Models;
using SportsLeagueManagement.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SportsLeagueManagement.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerViewModel>().ReverseMap();
            CreateMap<Team, TeamViewModel>().ReverseMap();
            CreateMap<Match, MatchViewModel>().ReverseMap();
            CreateMap<League, LeagueViewModel>().ReverseMap();
        }
    }
}