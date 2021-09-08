using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.DTOs;
using HairCutAPI.Entities;
using HairCutAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly HDBContext _context;

        private readonly ITokenService _tokenService;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, HDBContext context, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _tokenService = tokenService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO dto)
        {
            if (await UserExists(dto.UserName))
            {
                return BadRequest("Username is taken");
            }

            using var hmac = new HMACSHA512();
            var newUser = new AppUser()
            {
                UserName = dto.UserName.ToLower(),
            };

            //Save New User to Database
            var result = await _userManager.CreateAsync(newUser, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            //Save User's role
            var roleResult = await _userManager.AddToRoleAsync(newUser, "Customer");
            if (!roleResult.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return new UserDTO()
            {
                Username = newUser.UserName,
                Token = await _tokenService.CreateToken(newUser)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            //Check if user exists
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return new UserDTO()
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username.ToLower());
        }
    }
}
