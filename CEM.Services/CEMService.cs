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
        private bool CheckExistingAccount(string phoneNo)
        {
            return _dbContext.Users.Any(x => x.PhoneNo == phoneNo);
        }

        public async Task<Complain> AddComplainAsync(Complain complain)
        {
            complain.Date =  DateTime.Now;
            await _dbContext.Complains.AddAsync(complain);
            await _dbContext.SaveChangesAsync();
            return complain;
        }

        IEnumerable<Complain> ICEMService.GetAllComplainsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginAsync(string phoneNo, string password)
        {
            var existUser = CheckExistingAccount(phoneNo);
            if(!existUser)
            {
                return await Task.FromResult(new User());
            }
            var user = await _dbContext.Users.SingleAsync(x => x.PhoneNo == phoneNo);
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
            var casted = _dbContext.Complains.Where(x => x.UserId == Id).ToList();

            return casted;
        }
    }
}
