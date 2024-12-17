using StorageWebApi.Data.Models;

namespace StorageWebApi.Data.Repositories
{
    public interface IUsersRepo
    {
        User CreateUser(User entity);
        bool DeleteUser(Guid id);
        User? GetUser(Guid id);
        bool CheckIfUserExists(string email);
        User? GetUserByEmail(string email);
    }
}