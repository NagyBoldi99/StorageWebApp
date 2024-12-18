using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using StorageWebApi.Data.DTO;
using StorageWebApi.Data.Models;
using StorageWebApi.Data.Repositories;

namespace StorageWebApi.Services
{

    public class UserService : IUserService
    {
        private readonly IUsersRepo _usersrepo;
        public UserService(IUsersRepo usersrepo)
        {
            _usersrepo = usersrepo;
        }
        public bool Registration(RegistrationUserDto dto)
        {
            if (_usersrepo.CheckIfUserExists(dto.Email) == true)
            {
                return false;
            }

            var salt = RandomNumberGenerator.GetBytes(128 / 8);
            var hashed = HashPassword(dto.Password, salt);
            var entity = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                BirthDate = dto.BirthDate,
                PasswordHash = hashed,
                Salt = Convert.ToBase64String(salt)
            };
            _usersrepo.CreateUser(entity);
            return true;

        }
        public string Login(LoginUserDto dto)
        {

            var entity = _usersrepo.GetUserByEmail(dto.Email);
            if (entity == null)
            {
                return string.Empty;
            }
            var salt = Convert.FromBase64String(entity.Salt);
            var passwordHash = HashPassword(dto.Password, salt);
            if (passwordHash.Equals(entity.PasswordHash))
            {
                return entity.Id.ToString();
            }
            return string.Empty;
        }
        private string HashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        
    }
}
