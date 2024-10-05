using UESAN.StoreDB.DOMAIN.Core.Entities;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SignIn(string email, string pwd);
        Task<bool> SignUp(User user);
    }
}