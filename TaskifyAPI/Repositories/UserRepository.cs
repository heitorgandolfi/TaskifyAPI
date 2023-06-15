using Microsoft.EntityFrameworkCore;
using TaskifyAPI.Data;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interfaces;

namespace TaskifyAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemTaskDBContext _dbContext;
        public UserRepository(SystemTaskDBContext systemTaskDBContext)
        {
            _dbContext = systemTaskDBContext;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> GetUser(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userByID = await GetUser(id);

            if (userByID == null)
            {
                throw new Exception($"There is no User with this id: {id}");
            }

            userByID.Name = user.Name;
            userByID.Email = user.Email;

            _dbContext.Users.Update(userByID);
            await _dbContext.SaveChangesAsync();

            return userByID;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUser(id);

            if (userById == null)
            {
                throw new NotImplementedException($"There is no User with this id: {id}");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
