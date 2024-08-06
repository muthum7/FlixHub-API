using FlixHub.Models;
namespace FlixHub.Repository.UserRepo
{
    public interface IUserRepository
    {
        //GET
        User GetUser(string email, string password);
        //POST
        bool InsertUser(User user);
        //PUT
        bool UpdateUser(string email, User user);

    }
}
