using AutoMapper;
using FlixHub.DTO.UserDTO;
using FlixHub.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlixHub.Repository.UserRepo
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserServices(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public string LogInUser(string email, string password)
        {
            var result = _userRepository.GetUser(email, password);
            if (result == null)
            {
                return null;
            }

            var user = _mapper.Map<UserResponseDTO>(result);
            var token = GenerateJwtToken(user);
            return token;
        }

        public bool RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var user = _mapper.Map<User>(userRegisterDTO);
            var result = _userRepository.InsertUser(user);
            return result;
        }

        public string GenerateJwtToken(UserResponseDTO userResDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
         new Claim("Id",userResDto.Id.ToString()),
         new Claim(ClaimTypes.Email , userResDto.Email),
         new Claim(ClaimTypes.Name , userResDto.Name),
         new Claim(ClaimTypes.Role, userResDto.Role)
     };
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
