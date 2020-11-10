using MediSmartTestApi.ApplicationService;
using MediSmartTestApi.Models;
using MediSmartTestApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediSmartTestApi.Controllers
{
    [Route("api/[controller]")]
    public class UserDataController : BaseApiController
    {
        private readonly IUserDataService _userDataService;
        public UserDataController(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        [HttpPost, Route("AddUserData")]
        public async Task<ResponseBase> AddUserData([FromBody] UserData userData)
        {
            try
            {
                await _userDataService.CreateUserData(userData);

                return new ResponseBase() { IsSuccess = true, ErrorDetails = null };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ResponseBase() { ErrorDetails = Error(), IsSuccess = false };
            }
        }

        [HttpGet, Route("DeleteUserData")]
        public async Task<ResponseBase> DeleteUserData([FromQuery] int UserId)
        {
            try
            {
                await _userDataService.DeleteUserData(UserId);

                return new ResponseBase() { IsSuccess = true, ErrorDetails = null };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ResponseBase() { ErrorDetails = Error(), IsSuccess = false };
            }
        }
        
        [HttpGet, Route("GetUserData")]
        public async Task<ResponseBase> GetUserData()
        {
            try
            {
                var result = await _userDataService.GetAllUserDatas();

                return new ResponseBase<IEnumerable<UserData>>() { IsSuccess = true, ErrorDetails = null, Payload = result };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ResponseBase() { ErrorDetails = Error(), IsSuccess = false };
            }
        }

        [HttpPost, Route("UpdateUserData")]
        public async Task<ResponseBase> UpdateUserData([FromBody] UserData userData)
        {
            try
            {
                await _userDataService.UpdateUserData(userData);

                return new ResponseBase() { IsSuccess = true, ErrorDetails = null };
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new ResponseBase() { ErrorDetails = Error(), IsSuccess = false };
            }
        }
    }
}
