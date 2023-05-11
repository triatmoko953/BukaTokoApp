using AutoMapper;
using BukaToko.Data;
using BukaToko.DTOS;
using BukaToko.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

using BC = BCrypt.Net.BCrypt;
using BukaToko.SyncService;

namespace BukaToko.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IGooleDataClient _gooleDataClient;

        public AccountController(IAccountRepo userRepo, IMapper mapper,IGooleDataClient gooleDataClient)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _gooleDataClient = gooleDataClient;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);
            _userRepo.Register(user);
            _userRepo.SaveChanges();

            return Ok("Registrasi sukses");
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var userToken = _userRepo.Login(loginUserDto);
            return Ok(userToken);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Banned")]
        public async Task<IActionResult> Banned(BannedUserDto bannedUserDto)
        {
            var Message = _userRepo.Banned(bannedUserDto);
            return Ok(Message);
        }
    }
}
