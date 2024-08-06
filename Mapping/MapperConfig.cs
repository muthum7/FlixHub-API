using AutoMapper;
using FlixHub.DTO.BookingDTO;
using FlixHub.DTO.MovieDTO;
using FlixHub.DTO.TheatreDTO;
using FlixHub.DTO.UserDTO;
using FlixHub.Models;

namespace FlixHub.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserResponseDTO, User>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();

            CreateMap<MovieDetailsDTO, Movie>().ReverseMap();

            CreateMap<MovieRequestDTO, Movie>();
            CreateMap<Movie, MovieResponseDTO>();


            CreateMap<MovieResponseDTO, Movie>().ReverseMap();
            CreateMap<MovieRequestDTO, Movie>().ReverseMap();

            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();

            CreateMap<TheatreDetailsDTO, Theatre>().ReverseMap();
            CreateMap<TheatreRequestDTO, Theatre>().ReverseMap();

            CreateMap<BookingRequestDTO, Booking>().ReverseMap();
            //CreateMap<BookingResponseDTO, Booking>();
            CreateMap<BookingRequestDTO,BookingResponseDTO>().ReverseMap(); 
            CreateMap<Booking, BookingResponseDTO>().ReverseMap();

            
            
        }
    }
}
