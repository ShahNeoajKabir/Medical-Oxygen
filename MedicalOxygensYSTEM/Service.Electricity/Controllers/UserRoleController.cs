using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using ModelClass.ViewModel;
using Newtonsoft.Json;
using SecurityBLLManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Oxygen.Controllers
{
    [Route("api/UserRole")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleBLLManager _bLLManager;

        public UserRoleController(IUserRoleBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }

        [HttpPost]
        [Route("AddUserRole")]
        public async Task<ActionResult>AddUserRole([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                userRole.CreatedBy = "Tanbin";
                return Ok(await _bLLManager.AddUserRole(userRole));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ActiveUserRole")]
        public List<UserRole> ActiveUserRole()
        {
            try
            {
                List<UserRole> userRoles = _bLLManager.GetActive();
                return userRoles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("DeactiveUserRole")]
        public List<UserRole> DeactiveUserRole()
        {
            try
            {
                List<UserRole> userRoles = _bLLManager.GetDeactive();
                return userRoles;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<ActionResult>UpdateUserRole([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                userRole.UpdatedBy = "Tanbin";
                return Ok(await _bLLManager.UpdateUserRole(userRole));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("DeleteUserRole")]
        public async Task<ActionResult> DeleteUserRole([FromBody] TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                return Ok(await _bLLManager.DeleteUserRole(userRole));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(userRole));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
