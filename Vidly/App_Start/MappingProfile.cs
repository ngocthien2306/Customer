using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.DTO;
namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();

            Mapper.CreateMap<MemberShipType, MembershipTypeDTO>();

            Mapper.CreateMap<Genres, GenreDTO>();
        }
    }
}