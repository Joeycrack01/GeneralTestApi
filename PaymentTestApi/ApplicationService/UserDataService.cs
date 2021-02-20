using MediSmartTestApi.Models;
using MediSmartTestApi.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.ApplicationService
{
    public class UserDataService : IUserDataService
    {
        private readonly DataContext _context;
        public UserDataService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserData>> GetAllUserDatas()
        {
            var courses = await _context.UserDatas.ToListAsync();
            return courses;
        }

        public async Task<UserData> GetUserDataById(int userDataId)
        {
            var courses = await _context.UserDatas.Where(c => c.ID == userDataId).FirstOrDefaultAsync();
            return courses;
        }

        public async Task CreateUserData(UserData userData)
        {
            _context.UserDatas.Add(userData);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserData(UserData userData)
        {
            //var _userData = await GetUserDataById(userData.ID);
            //_userData.AccountNumber = userData.AccountNumber;
            //_userData.Bvn = userData.Bvn;
            //_userData.CompanyAddress = userData.CompanyAddress;
            //_userData.CompanyName = userData.CompanyName;
            //_userData.Department = userData.Department;
            //_userData.FirstName = userData.FirstName;
            //_userData.LastName = userData.LastName;
            //_userData.StaffId = userData.StaffId;
            //_userData.StateOfOrigin = userData.StateOfOrigin;


            _context.UserDatas.Update(userData);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserData(int userDataId)
        {
            var userData = await GetUserDataById(userDataId);
            _context.UserDatas.Remove(userData);
            await _context.SaveChangesAsync();
        }
    }
}
