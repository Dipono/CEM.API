using CEM.Model.Model;
using System.Reflection.Metadata;

namespace CEM.Services
{
    public interface ICEMService
    {
        Task<User> LoginAsync(string email, string password);
        Task<User> RegisterUserAsync(User user);
        Task<Complain> AddComplainAsync(Complain complain);
        IEnumerable<Complain> GetComplainsByUserId(int empId);
        IEnumerable<User_Complain> GetComplainResponse(int user_complainId);
        string ChangeClosedLog(int compalinId);
        string ChangeSatisfaction(int compalinId);
        Task<User_Complain> AddUserRespond(User_Complain complain);
        IEnumerable<UserComplainDetails> GetAllAllUsersDetailsAsync();
        Task<Forum> AddTopicToForumAsync(Forum forum);
        IEnumerable<UsersForum> GetAllAllUsersForumAsync();
        IEnumerable<Forum> GetAllTopicForumAsync();

    }
}