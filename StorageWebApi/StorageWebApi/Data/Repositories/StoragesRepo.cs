using Microsoft.EntityFrameworkCore;
using StorageWebApi.Data.Models;

namespace StorageWebApi.Data.Repositories
{
    public class StoragesRepo : IStoragesRepo
    {
        private readonly SWDbContext _dbContext;

        public StoragesRepo(SWDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Storage> GetAllStorages()
        {
            return _dbContext.Storages.ToList();
        }

        public Storage? GetStorageById(Guid id)
        {
            var storage = _dbContext.Set<Storage>().Find(id);

            return storage;
        }

        public IEnumerable<Storage> GetByOwnerId(Guid ownerId)
        {
            return _dbContext.Storages.Include(s=>s.Owner).Where(s => s.Owner.Id == ownerId).ToList();
        }

        public void AddStorage(Storage storage)
        {
            _dbContext.Storages.Add(storage);
            _dbContext.SaveChanges();
        }

        public void Update(Storage storage)
        {
            _dbContext.Storages.Update(storage);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var storage = GetStorageById(id);
            if (storage != null)
            {
                _dbContext.Storages.Remove(storage);
                _dbContext.SaveChanges();
            }
        }
    }
}
