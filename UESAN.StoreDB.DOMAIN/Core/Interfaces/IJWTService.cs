using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Settings;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface IJWTService
    {
        JWTSettings _settings { get; }

        string GenerateJWToken(User user);
    }
}