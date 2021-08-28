using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelClass.DTO;
using ModelClass.ViewModel;
using Newtonsoft.Json;
using SecurityBLLManager.Interfaces;
using Service.Electricity.MailConfig;

namespace Service.Oxygen.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager userBLLManager;
        public UserController(IUserBLLManager userBLLManager)
        {
            this.userBLLManager = userBLLManager;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                

                return Ok(await this.userBLLManager.AddUser(user));
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpGet]
        [Route("GetAll")]
        public List<User> GetAll()
        {
            List<User> user = this.userBLLManager.GetAllUser();
            return user;
        }

        [HttpGet]
        [Route("GetModerator")]
        public List<User> GetModerator()
        {
            List<User> user = this.userBLLManager.GetModerator();
            return user;
        }


        [HttpGet]
        [Route("GetDeliveryMan")]
        public List<User> GetDeliveryMan()
        {
            List<User> user = this.userBLLManager.GetDeliveryMan();
            return user;
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public List<User> GetAllCustomer()
        {
            List<User> user = this.userBLLManager.GetAllCustomer();
            return user;
        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult>UpdateUser([FromBody]TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                return Ok(await this.userBLLManager.UpdateUser(user));
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        [HttpPost]
        [Route("DeleteUser")]
        public async Task<ActionResult>DeleteUser([FromBody]TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                return Ok(await this.userBLLManager.DeleteUser(user));
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
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());

                return Ok(await this.userBLLManager.GetById(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }


    }
}
