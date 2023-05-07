using BukaToko.Models;

namespace BukaToko.Data
{
    public interface IUserRepo
    {
        Task Login(User user);
    }
}
