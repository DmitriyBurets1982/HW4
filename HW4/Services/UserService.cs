using HW4.Contracts;
using HW4.DataAccess;
using HW4.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW4.Services
{
    public class UserService(UsersDbContext dbContext) : IUserService
    {
        public async Task<UserModel?> GetUser(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user != null ? new UserModel { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName } : null;
        }

        public async Task<UserModel> CreateUser(UserCreateModel model)
        {
            var newUser = new User { FirstName = model.FirstName, LastName = model.LastName };
            await dbContext.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return new UserModel { Id = newUser.Id, FirstName = newUser.FirstName, LastName = newUser.LastName };
        }

        public async Task<UserModel?> UpdateUser(UserModel model)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (user != null) 
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                await dbContext.SaveChangesAsync();

                return new UserModel { Id = user.Id, FirstName = user.FirstName, LastName= user.LastName };
            }

            return null;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
