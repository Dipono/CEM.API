using CEM.Model.Model;
using System.Reflection.Metadata;

namespace CEM.Services
{
    public interface ICEMService
    {
        Task<User> LoginAsync(string email, string password);
        Task<User> RegisterUserAsync(User user);
        Task<Complain> AddComplainAsync(Complain complain);
        IEnumerable<Complain> GetAllComplainsAsync();
        IEnumerable<Complain> GetComplainsByUserId(int empId);

    }
}