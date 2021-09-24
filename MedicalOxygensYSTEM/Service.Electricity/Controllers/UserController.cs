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
                var loginedUser = (User)HttpContext.Items["User"];
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                user.CreatedBy = loginedUser.UserName;

                return Ok(await this.userBLLManager.AddUser(user));
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll([FromBody] TempMessage message)
        {
            try
            {

                return Ok(await this.userBLLManager.GetAll());
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [Route("GetModerator")]
        public async Task<ActionResult> GetModerator([FromBody] TempMessage message)
        {
            try
            {

                return Ok(await this.userBLLManager.GetAllModerator());
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        [HttpPost]
        [Route("GetDeliveryMan")]
        public async Task<ActionResult> GetDeliveryMan([FromBody] TempMessage message)
        {
            try
            {

                return Ok(await this.userBLLManager.GetDeliveryMan());
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<ActionResult> GetAllCustomer([FromBody] TempMessage message)
        {
            try
            {

                return Ok(await this.userBLLManager.GetCustomer());
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("UpdateUser")]
        public async Task<ActionResult>UpdateUser([FromBody]TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                user.UserName = "Tanbin";
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
        [Route("GetbyID")]
        public async Task<ActionResult> GetbyID([FromBody] TempMessage message)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<int>(message.Content.ToString());

                return Ok(await this.userBLLManager.GetById(user));

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        [Route("Registration")]
        public async Task<ActionResult> Registration([FromBody] TempMessage message)
        {
            try
            {
                //await _mailer.SendEmailAsync("bappyron@gmail.com", "Test", "Pending Customer");

                User customer = JsonConvert.DeserializeObject<User>(message.Content.ToString());

                await this.userBLLManager.AddCustomer(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


    }
}
