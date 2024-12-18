using StorageWebApi.Data.DTO;
using StorageWebApi.Data.Models;
using StorageWebApi.Data.Repositories;

namespace StorageWebApi.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStoragesRepo _storagesRepo;
        private readonly IUsersRepo _usersRepo;
        public StorageService(IStoragesRepo storagesRepo, IUsersRepo usersRepo)
        {
            _storagesRepo = storagesRepo;
            _usersRepo = usersRepo;
        }

        public void CreateStorage(CreateStorageDto dto)
        {


            var storage = new Storage
            {
                Sid = Guid.NewGuid(),
                Sname = dto.Sname,
                Sdescription = dto.Sdescription,
                Sarea = dto.Sarea,
                OwnerId = dto.OwnerId != Guid.Empty
                  ? dto.OwnerId
                  : Guid.Empty
            };

            _storagesRepo.AddStorage(storage);
        }

        public Storage? FindStorageById(Guid id)
        {
            return _storagesRepo.GetStorageById(id);
        }

        public IEnumerable<Storage> FindAllStorages()
        {
            return _storagesRepo.GetAllStorages();
        }

        public void DeleteStorage(Guid id)
        {
            _storagesRepo.Delete(id);
        }
    }
}
