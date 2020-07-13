using System.Collections;
using System.Collections.Generic;
using MiqManga.Data.Entities;

namespace MiqManga.Services
{
    public interface IAuthServices
    {
        User Register(User newUser, string password);
        User Login(string username, string password);
    }
}