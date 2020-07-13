using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MiqManga.Data;
using MiqManga.Data.Entities;

namespace MiqManga.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly MiqMangaDbContext _context;

        public AuthServices(MiqMangaDbContext context)
        {
            _context = context;
        }

        public User Register(User newUser, string password)
        {
            var userFromDb =
                _context.Users.FirstOrDefault(u => u.Username == newUser.Username || u.Email == newUser.Email);

            if (userFromDb != null)
            {
                return null;
            }

            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            newUser.PasswordSalt = Convert.ToBase64String(passwordSalt);
            newUser.PasswordHash = Convert.ToBase64String(passwordHash);

            var addResult = _context.Users.Add(newUser);

            var isSaved = _context.SaveChanges() > 0;

            if (!isSaved)
            {
                return null;
            }

            return addResult.Entity;
        }

        public User Login(string username, string password)
        {
            var userFromDb = _context.Users.FirstOrDefault(u => u.Username == username);

            if (userFromDb == null)
            {
                return null;
            }

            var verified = VerifyPassword(password, userFromDb.PasswordHash, userFromDb.PasswordSalt);
            if (verified)
            {
                return userFromDb;
            }

            return null;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, string passwordHash, string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                hmac.Key = Convert.FromBase64String(passwordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var ph = Convert.FromBase64String(passwordHash);
                
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != ph[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}