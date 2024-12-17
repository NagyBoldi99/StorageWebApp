using StorageWebApi.Data.Models;

namespace StorageWebApi.Data.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly SWDbContext _dbContext;
        public UsersRepo(SWDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User CreateUser(User entity)
        {

            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public User? GetUser(Guid id)
        {
            var user = _dbContext.Set<User>().Find(id);

            return user;
        }
        public bool DeleteUser(Guid id)
        {
            var user = GetUser(id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Set<User>().Remove(user);
            _dbContext.SaveChanges();
            return true;
        }
        public bool CheckIfUserExists(string email)
        {
            var entity = _dbContext.Set<User>().FirstOrDefault(x => x.Email == email);
            return entity != null;
            
        }
        public User? GetUserByEmail(string email)
        {
            var entity = _dbContext.Set<User>().FirstOrDefault(x => x.Email == email);
            return entity;

        }
    }
}

