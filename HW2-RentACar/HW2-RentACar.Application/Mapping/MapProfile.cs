using AutoMapper;
using HW2_RenACar.Domain.Entities;
using HW2_RentACar.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_RentACar.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }

    }
}
