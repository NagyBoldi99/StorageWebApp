using StorageWebApi.Data.Models;

namespace StorageWebApi.Data.Repositories
{
    public interface IStoragesRepo
    {
        void AddStorage(Storage storage);
        void Delete(Guid id);
        IEnumerable<Storage> GetAllStorages();
        IEnumerable<Storage> GetByOwnerId(Guid ownerId);
        Storage? GetStorageById(Guid id);
        void Update(Storage storage);
    }
}