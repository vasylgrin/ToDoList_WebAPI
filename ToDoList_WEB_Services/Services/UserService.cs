using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList_WEB_Domain.DomainModels;
using ToDoList_WEB_Domain.Mappers;
using ToDoList_WEB_Entity.Models;
using ToDoList_WEB_Repositories.Interfaces;
using ToDoList_WEB_Repositories.Repositories;

namespace ToDoList_WEB_Services.Services
{
    public sealed class UserService
    {
        private readonly IRepositoryBase<User> _repositoryBase;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _repositoryBase = new SQLiteRepositroy<User>();
            _configuration = configuration;
        }


        public async Task<UserDTO> AddNewUserAsync(UserDTO newUser)
        {
            if (newUser is null)
            {
                throw new ArgumentNullException(nameof(newUser), $"Input '{nameof(newUser)}' cannot be null.");
            }

            var user = await _repositoryBase.FindAsync(user => user.Login == newUser.Login);
            if(user is not null)
            {
                throw new Exception("This login has already existed.");
            }

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _repositoryBase.AddAsync(newUser.ToUser());
            return newUser;
        }


        public async Task<string> FindUserAsync(LoginDataDTO loginDataDTO)
        {
            if (string.IsNullOrWhiteSpace(loginDataDTO.Login))
            {
                throw new ArgumentNullException($"'{nameof(loginDataDTO.Login)}' cannot be null or whitespace.", nameof(loginDataDTO.Login));
            }
            else if (string.IsNullOrWhiteSpace(loginDataDTO.Password))
            {
                throw new ArgumentNullException($"'{nameof(loginDataDTO.Password)}' cannot be null or whitespace.", nameof(loginDataDTO.Password));
            }

            var user = await _repositoryBase.FindAsync(user => user.Login == loginDataDTO.Login);
            var isCorrectedPassword = BCrypt.Net.BCrypt.Verify(loginDataDTO.Password, user.PasswordHash);

            if (isCorrectedPassword)
            {
                return GenerateToken(user.ToUserDTO());
            }

            return null;
        }


        public async IAsyncEnumerable<ToDoDTO> LoadUsersToDoes(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or whitespace.", nameof(login));
            }

            var userWithToDoes = await _repositoryBase.IncludeAsync(u=>u.Login == login, t=>t.ToDoes);
            foreach(var toDo in userWithToDoes.ToDoes)
            {
                yield return toDo.ToToDoDTO();
            }
        }



        private string GenerateToken(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Login),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issure"], 
                audience: _configuration["Jwt:Audience"], 
                claims: claims, 
                expires: DateTime.Now.AddDays(5), 
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
