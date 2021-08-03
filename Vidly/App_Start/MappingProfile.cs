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
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDTO>();

            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.MovieID, opt => opt.Ignore());
            Mapper.CreateMap<MembershipTypeDTO, MemberShipType>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}