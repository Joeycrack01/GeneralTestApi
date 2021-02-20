using MediSmartTestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediSmartTestApi.ApplicationService
{
    public interface IUserDataService
    {
        Task CreateUserData(UserData userData);
        Task DeleteUserData(int userData);
        Task<IEnumerable<UserData>> GetAllUserDatas();
        Task<UserData> GetUserDataById(int userDataId);
        Task UpdateUserData(UserData userData);
    }
}