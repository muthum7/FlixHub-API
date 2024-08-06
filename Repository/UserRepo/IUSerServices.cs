using FlixHub.DTO.UserDTO;

namespace FlixHub.Repository.UserRepo
{
    public interface IUserServices
    {
        string LogInUser(string email, string password);

        bool RegisterUser(UserRegisterDTO userRegisterDTO);
    }
}
