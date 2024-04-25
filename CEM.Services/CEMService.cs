using CEM.Model;
using CEM.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEM.Services
{
    public class CEMService : ICEMService
    {
        private readonly CEMDbContext _dbContext;

        public CEMService(CEMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Checking whether the account exist or not
        private bool CheckExistingAccount(string email)
        {
            return _dbContext.Users.Any(x => x.Email == email);
        }

        public async Task<Complain> AddComplainAsync(Complain complain)
        {
            complain.Date =  DateTime.Now;
            await _dbContext.Complains.AddAsync(complain);
            await _dbContext.SaveChangesAsync();
            return complain;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var existUser = CheckExistingAccount(email);
            if(!existUser)
            {
                return await Task.FromResult(new User());
            }
            var user = await _dbContext.Users.SingleAsync(x => x.Email == email);
            if (user.Password == password)
            {
                return user;
            }
            return await Task.FromResult(new User());
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            user.Role = "customer";
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public IEnumerable<Complain> GetComplainsByUserId(int Id)
        {
            var complainList = _dbContext.Complains.Where(x => x.UserId == Id).ToList();

            return complainList;
        }

        public IEnumerable<User_Complain> GetComplainResponse(int user_complainId)
        {
            var complainListRespond = _dbContext.User_Complains.Where(x => x.ComplainId == user_complainId).ToList();

            return complainListRespond;
        }

        public string ChangeClosedLog(int compalinId)
        {
            var costermerComplain = _dbContext.Complains.SingleOrDefault(k => k.Id == compalinId);
            costermerComplain.Closed = true;
            _dbContext.SaveChanges();
            return "Updated successefully";
        }

        public Boolean CheckExistingEmail(string email)
        {
            return CheckExistingAccount(email);
        }
        public Boolean ForgotPassword(User user)
        {
            var existingUser = _dbContext.Users.SingleOrDefault(k => k.Email == user.Email);

            existingUser.Password = user.Password;
            _dbContext.SaveChanges();
            return true;
        }


        public string ChangeSatisfaction(int compalinId)
        {
            var costermerComplain = _dbContext.Complains.SingleOrDefault(k => k.Id == compalinId);
            costermerComplain.Satisfied = true;
            _dbContext.SaveChanges();
            return "Updated successefully";
        }

        public async Task<User_Complain> AddUserRespond(User_Complain user_respond)
        {
            user_respond.DateCreated = DateTime.Now;
            await _dbContext.User_Complains.AddAsync(user_respond);
            await _dbContext.SaveChangesAsync();
            return user_respond;
        }

        public IEnumerable<UserComplainDetails> GetAllAllUsersDetailsAsync()
        {
            var complainList = (from B in _dbContext.Complains
                               join A in _dbContext.Users on B.UserId
                               equals A.Id
                               select new UserComplainDetails()
                               { 
                                   UserId = B.UserId,
                                   Surname = A.Surname,
                                   Name = A.Name,
                                   PhoneNo = A.PhoneNo,
                                   Id = B.Id,
                                   ComplainId=B.Id,
                                   Subject = B.Subject,
                                   SubjectDescription= B.ComplainDescription,
                                   Closed = B.Closed,
                                   Satisfied = B.Satisfied,
                                   DateCreated = B.Date,
                                   Location= B.Location
                               }).ToList();

            return complainList;
        }

        public async Task<Forum> AddTopicToForumAsync(Forum forum)
        {
            forum.DateCreated = DateTime.Now;
            await _dbContext.Forums.AddAsync(forum);
            await _dbContext.SaveChangesAsync();
            return forum;
        }

        public IEnumerable<Forum> GetAllTopicForumAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersForum> GetAllAllUsersForumAsync()
        {
            var complainList = (from B in _dbContext.Forums
                                join A in _dbContext.Users on B.UserId
                                equals A.Id
                                select new UsersForum()
                                {
                                    UserId = B.UserId,
                                    Surname = A.Surname,
                                    Name = A.Name,
                                    TopicDescription = B.TopicDescription,
                                    Id = B.Id,
                                    ForumId = B.Id,
                                    Topic = B.Topic,
                                    DateCreated = B.DateCreated
                                }).ToList();

            return complainList;
        }

    }
}
