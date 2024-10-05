using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseAuthDTO> SignIn(string email, string password);
        Task<bool> SignUp(UserRequestAuthDTO userDTO);
    }
}