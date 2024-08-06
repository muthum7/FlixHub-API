using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FlixHub.DTO.UserDTO;
using FlixHub.Models;
using FlixHub.Repository.UserRepo;
using System.ComponentModel.DataAnnotations;

namespace FlixHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUserServices userServices, IUserRepository userRepository, IMapper mapper)
        {
            _userServices = userServices;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used for User and Admin Login validation
        /// </summary>
        /// <param name="userLoginDTO"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{email}/{password}")]
        public IActionResult Login([FromRoute] string email, [FromRoute] string password)
        {
            if (email.Trim() == "" || password.Trim() == "")
            {
                return BadRequest("Invalid User Data");
            }
            var res = _userServices.LogInUser(email, password);
            if (res == null) { return NotFound(); }
            return Ok(new { Token = res });
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(UserRegisterDTO userReq)
        {
            var result = _userServices.RegisterUser(userReq);
            if (result == false)
            {
                return BadRequest($"User with email {userReq.Email} already exists");
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }
        [HttpPut("Update")]
        public IActionResult UpdateUser(string email,[FromForm] UserUpdateDTO userUpdateDTO)
        {
            var mapped = _mapper.Map<User>(userUpdateDTO);
            bool user = _userRepository.UpdateUser(email, mapped);
            if (user == true) 
            {
                return Ok("Updated Successfully");
            }
            return BadRequest();
        }
    }
}