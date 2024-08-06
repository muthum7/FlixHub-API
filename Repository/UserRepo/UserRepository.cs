using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using FlixHub.Data;
using FlixHub.Models;

namespace FlixHub.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }

        public bool UserExists(string Email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null) return false;
            return true;
        }

        public bool InsertUser(User user)
        {
            if (UserExists(user.Email)) return false;
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(string email, User user)
        {
            var currUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (currUser == null) return false;
            currUser.Name = user.Name;
            currUser.Email = user.Email;
            currUser.Password = user.Password;
            currUser.Contact = user.Contact;
            _context.SaveChanges();
            return true;
        }
    }
}
