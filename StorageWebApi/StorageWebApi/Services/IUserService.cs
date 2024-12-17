using StorageWebApi.Data.DTO;

namespace StorageWebApi.Services
{
    public interface IUserService
    {
        bool Registration(RegistrationUserDto dto);
        bool Login(LoginUserDto dto);
    }
}