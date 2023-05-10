﻿using BukaToko.DTOS;
using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IAccountRepo
    {
        string Register (User user);
        UserToken Login (LoginUserDto user);
        bool SaveChanges();
    }
}