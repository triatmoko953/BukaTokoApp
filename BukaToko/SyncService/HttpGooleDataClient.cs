using BukaToko.DTOS;
using System.Text.Json;
using System.Text;
using BukaToko.Models;
using BukaToko.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BukaToko.SyncService
{
    public class HttpGooleDataClient : IGooleDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IAccountRepo _accountRepo;
        private readonly BukaTokoDbContext _context;

        public HttpGooleDataClient(HttpClient httpClient, IConfiguration configuration, IAccountRepo accountRepo, BukaTokoDbContext context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _accountRepo = accountRepo;
            _context = context;

        }
        public async Task<UserToken> SendUserToGoole(LoginUserDto user)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PostAsync($"{_configuration["GooleService"]}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var u = await _context.Users.FirstOrDefaultAsync(p => p.Username == user.Username);
                if (u == null)
                {
                    throw new Exception("silahkan registrasi dahulu di bukatoko dengan username yang sama");
                }
                return _accountRepo.Login(user);
            }
            else
            {
                throw new Exception("Username salah silahkan di cek kembali, atau jika belum punya akun goole silahkan registrasi di goole dahulu");
            }         
        }
    }
}
