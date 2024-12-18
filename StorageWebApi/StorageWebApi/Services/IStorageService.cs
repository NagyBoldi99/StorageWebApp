using StorageWebApi.Data.DTO;
using StorageWebApi.Data.Models;

namespace StorageWebApi.Services
{
    public interface IStorageService
    {
        void CreateStorage(CreateStorageDto dto);
        void DeleteStorage(Guid id);
        IEnumerable<Storage> FindAllStorages();
        Storage? FindStorageById(Guid id);
    }
}