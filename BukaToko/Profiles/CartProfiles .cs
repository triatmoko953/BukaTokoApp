using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BukaToko.DTO;
using BukaToko.DTOS;
using BukaToko.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BukaToko.Profiles
{
    public class CartProfiles : Profile
    {
        public CartProfiles()
        {
            CreateMap<Cart, ReadCartDto>();
            CreateMap<CreateCartDto, Cart>();
        }
    }
}
