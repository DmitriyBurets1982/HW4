using HW4.Contracts;

namespace HW4.Services
{
    public interface IUserService
    {
        Task<UserModel?> GetUser(int id);
        Task<UserModel> CreateUser(UserCreateModel model);
        Task<UserModel?> UpdateUser(UserModel model);
        Task<bool> DeleteUser(int id);
    }
}
