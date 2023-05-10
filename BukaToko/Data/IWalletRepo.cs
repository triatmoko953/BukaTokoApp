using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IWalletRepo
    {
        Task<Wallet> TopUp(string username, int amount);
        bool ExternalWalletExists(string externalUsername);
        Task<IEnumerable<Wallet>> GetAllWallets();
        bool SaveChanges();
    }
}
